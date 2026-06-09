---
title: Kurulum
type: docs
weight: 70
url: /tr/python-java/installation/
keywords:
- Aspose.Slides indirme
- Aspose.Slides kur
- Aspose.Slides kurulumu
- Windows
- macOS
- Linux
- Python
description: "Aspose.Slides for Python via Java'i Windows, Linux veya macOS'ta kurun"
---
Aspose.Slides for Python via Java, platformdan bağımsız bir API'dir ve `Python`, `Java` ve `jpype1` köprüsü kurulu olan herhangi bir platformda (Windows, Linux ve macOS) kullanılabilir.

## **Programlar ve sürümler için gereksinimler**

Aspose.Slides for Python via Java'in düzgün çalışmasını sağlamak için aşağıdaki programlar ve paketler kurulmuş olmalıdır:

- JRE sürümü >=8 (JPype1, Java 1.8 ile 11 arasındaki sürümlerde test edilmiştir).
- Python sürümü >=3.7 ve <=3.12.
- JPype1 paket sürümü: >=1.5.0.

## **pip üzerinden kurulum**

Gerekli tüm programlar (Java, Python) kurulu olduğu sürece Aspose.Slides for Python via Java'i [pip](https://pypi.org/) üzerinden kolayca kurabilirsiniz.

Yeni bir proje klasörü oluşturun.

[JPype1'i kurun](https://jpype.readthedocs.io/en/latest/install.html) aşağıdaki komutu kullanarak:
```
$ pip install JPype1
```

Aspose.Slides for Python via Java'i aşağıdaki komutla kurun:
```
$ pip install aspose-slides-java
```

## **ZIP arşivinden kurulum**

Aspose.Slides for Python via Java'i bir ZIP arşivinden kurup kullanmak için aşağıdaki talimatları izleyin:

### **Windows**

1. JDK8'i kurun ve `JAVA_HOME` ortam değişkenini yapılandırın.
2. [Python](https://www.python.org/downloads/) sürüm >=3.7'yi kurun ve python.exe'yi `PATH`'e ekleyin.
3. [Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/)'u kurun.
4. [JPype1'i kurun](https://jpype.readthedocs.io/en/latest/install.html). Aşağıdaki komutları python terminalinde çalıştırabilirsiniz:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Aspose.Slides for Python via Java'i indirin](https://releases.aspose.com/slides/tr/python-java/) ve `aspose-slides-java` klasörüne çıkarın.
6. `aspose-slides-java` klasöründe `example.py` adlı bir dosya oluşturun ve aşağıdaki örnek kodu kullanın:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

7. Şimdi komut istemcisinde `py example.py` yazarak çalıştırın.

### **Linux**

1. Linux için JDK8'i kurun ve `JAVA_HOME` ortam değişkenini yapılandırın.
2. [Python](https://www.python.org/downloads/) sürüm >=3.7'yi kurun.
3. ``g++`` ve ``python-dev`` paketlerini kurun. 

- Debian/Ubuntu için:
```
    sudo apt-get install g++ python3-dev
    ```
- For RedHat-based:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html). You can run below commands in python terminal:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/tr/python-java/) and extract it to `aspose-slides-java`.
6. Create a test file named `example.py` using this sample code in `aspose-slides-java` folder:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. Now run `py example.py` @command prompt to run it.

### **Mac**

1. Install JDK8 for Mac and configure `JAVA_HOME` environment variable.
2. Modify JVMCapabilities section in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` with root privilege. `jdk1.8.x_xxx.jdk` depends on your jdk version. Make it look like this:
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
3. [Install Python](https://www.python.org/downloads/) version >=3.7.
4. Install GCC or Clang compilers depending on the Python`s version and platform.
5. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html). You can run below commands in python terminal:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/tr/python-java/) and extract it into `aspose-slides-java`.
7. Create a test file named `example.py` using this sample code in `aspose-slides-java` folder:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. Şimdi komut istemcisinde `python example.py` yazarak çalıştırın.