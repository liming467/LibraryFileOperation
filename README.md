# C++库文件添加辅助
C++库文件添加辅助：1）查找文件夹下具有某后缀名的所有文件名；2）根据文件名将某一文件夹下的对应文件复制到另一文件夹下



## 背景
1）对于需要使用静、动态库的c++工程，需要手动添加附件依赖项，即添加用到的.lib文件名。对于有需要的.lib很多时，手动一个个添加会非常低效，且令人抓狂~

2）对于使用动态库，除了要添加依赖项，在运行时还需要dll文件，一般需要提前将dll文件拷贝至.exe所在目录。如果根据运行过程中所提示的信息一一拷贝对应的dll，该过程也会相当低效且枯燥。


## 功能
针对上述两个提到的问题，写了个简单的小程序，对应的具有两个功能：

1）查找文件夹下具有某后缀名的所有文件名
![图片1](https://github.com/liming467/LibraryFileOperation/blob/master/img/Picture1.png)

2）根据文件名将某一文件夹下的对应文件复制到另一文件夹下
![图片2](https://github.com/liming467/LibraryFileOperation/blob/master/img/Picture1.png)


## 其他

1）LibraryFileOperation_boxed.exe可以直接运行，但没有在其他电脑试过，可能还需要.Net运行时环境或安装.Net SDK。
