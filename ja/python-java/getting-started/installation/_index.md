---
title: インストール
type: docs
weight: 70
url: /python-java/installation/
keySlides: "Aspose.Slidesのダウンロード、Aspose.Slidesのインストール、Aspose.Slidesのインストール、Windows、macOS、Linux、Python"
description: "Windows、Linux、またはmacOSでJava経由でPython用のAspose.Slidesをインストールします"
---

Java経由のPython用Aspose.Slidesはプラットフォームに依存しないAPIであり、`Python`、`Java`、および`jpype1`ブリッジがインストールされている任意のプラットフォーム（Windows、Linux、MacOS）で使用できます。

## **必要なプログラムとバージョン**

Java経由のPython用Aspose.Slidesが正常に動作するためには、以下のプログラムとパッケージをインストールする必要があります：

- JREバージョン >=8（JPype1はJavaバージョン1.8から11まででテストされています）。
- Pythonバージョン >=3.7,<=3.12。
- JPype1パッケージバージョン: >=1.5.0。

## **pipからインストール**

必要なプログラム（Java、Python）がすべてインストールされていれば、[pip](https://pypi.org/)から簡単にJava経由のPython用Aspose.Slidesをインストールできます。

新しいプロジェクトフォルダーを作成します。

次のコマンドを使用して[JPype1をインストール](https://jpype.readthedocs.io/en/latest/install.html)します：
```
$ pip install JPype1
```

次のコマンドを使用してJava経由のPython用Aspose.Slidesをインストールします：
```
$ pip install aspose-slides-java
```

## **ZIPアーカイブからインストール**

ZIPアーカイブからJava経由のPython用Aspose.Slidesをインストールして使用するには、代わりにこれらの手順に従ってください：

### **Windows**

1. JDK8をインストールし、`JAVA_HOME`環境変数を設定します。
2. [Python](https://www.python.org/downloads/)バージョン >=3.7をインストールし、python.exeを`PATH`に追加します。
3. [Microsoft C++ Build Toolsをインストール](https://visualstudio.microsoft.com/visual-cpp-build-tools/)します。
4. [JPype1をインストール](https://jpype.readthedocs.io/en/latest/install.html)します。以下のコマンドをPythonターミナルで実行できます：
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Java経由のPython用Aspose.Slidesをダウンロード](https://releases.aspose.com/slides/python-java/)し、`aspose-slides-java`に展開します。
6. `aspose-slides-java`フォルダー内に`example.py`という名前のファイルを作成し、以下のサンプルコードを使用します：

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("スライドタイトルの見出し")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

7. これで、コマンドプロンプトで`py example.py`を実行して実行します。

### **Linux**

1. Linux用のJDK8をインストールし、`JAVA_HOME`環境変数を設定します。
2. [Python](https://www.python.org/downloads/)バージョン >=3.7をインストールします。
3. ``g++``と``python-dev``をインストールします。

- Debian/Ubuntuの場合：
    ```
    sudo apt-get install g++ python3-dev
    ```
- RedHatベースの場合：
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [JPype1をインストール](https://jpype.readthedocs.io/en/latest/install.html)します。以下のコマンドをPythonターミナルで実行できます：
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Java経由のPython用Aspose.Slidesをダウンロード](https://releases.aspose.com/slides/python-java/)し、`aspose-slides-java`に展開します。
6. `aspose-slides-java`フォルダー内にこのサンプルコードを使用して`example.py`というテストファイルを作成します：

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("スライドタイトルの見出し")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. これで、コマンドプロンプトで`py example.py`を実行して実行します。

### **Mac**

1. Mac用のJDK8をインストールし、`JAVA_HOME`環境変数を設定します。
2. `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist`のJVMCapabilitiesセクションを管理者権限で修正します。`jdk1.8.x_xxx.jdk`はあなたのjdkのバージョンによります。次のように見えるようにします：
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
3. [Python](https://www.python.org/downloads/)バージョン >=3.7をインストールします。
4. Pythonのバージョンとプラットフォームに応じてGCCまたはClangコンパイラをインストールします。
5. [JPype1をインストール](https://jpype.readthedocs.io/en/latest/install.html)します。以下のコマンドをPythonターミナルで実行できます：
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Java経由のPython用Aspose.Slidesをダウンロード](https://releases.aspose.com/slides/python-java/)し、`aspose-slides-java`に展開します。
7. `aspose-slides-java`フォルダー内にこのサンプルコードを使用して`example.py`というテストファイルを作成します：

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("スライドタイトルの見出し")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. これで、コマンドプロンプトで`python example.py`を実行して実行します。