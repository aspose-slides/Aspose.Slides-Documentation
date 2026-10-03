---
title: Системные требования
type: docs
weight: 60
url: /ru/java/system-requirements/
keywords:
- системные требования
- поддерживаемые платформы
- версии Java
- JDK
- JRE
- fontconfig
- шрифты
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, что требуется Aspose.Slides for Java перед установкой: поддерживаемые версии Java и операционные системы, а также библиотека шрифтов и шрифты, необходимые для Linux."
---
## **Введение**

Aspose.Slides for Java — это автономная библиотека: она не требует Microsoft PowerPoint или Microsoft Office. Это один файл JAR, опубликованный в Maven‑репозитории Aspose. Файл JAR содержит только классы Java и ресурсы, не имеет нативных библиотек и не объявляет зависимостей от других библиотек. Поэтому этот файл работает на любой операционной системе и процессоре, для которых доступна поддерживаемая среда выполнения Java.

В этой статье перечислены поддерживаемые версии Java и операционные системы, а также библиотека шрифтов и шрифты, необходимые для Linux, и в конце приведена небольшая программа, проверяющая вашу конфигурацию. Чтобы добавить библиотеку в проект, см. [Installation](/slides/ru/java/installation/).

## **Поддерживаемые версии Java**

Aspose.Slides for Java работает на Java 8 и выше, с JDK или JRE. Это включает версии с длительной поддержкой Java 8, 11, 17, 21 и 25, а также более новые версии, такие как Java 26 и Java 27. Среда выполнения Java может поставляться любым поставщиком, например Eclipse Temurin, Amazon Corretto, Oracle или пакетами OpenJDK в дистрибутиве Linux.

Aspose.Slides не требует параметров JVM, например `--add-opens`, в любой из этих версий. На Java 11 JVM выводит предупреждение, начинающееся с «WARNING: An illegal reflective access operation has occurred»; предупреждение не влияет на результат.

{{% alert color="warning" title="Warning" %}}
Java 6 и Java 7 устарели. Aspose.Slides for Java 26.9 всё ещё работает с ними, но выводит предупреждение об устаревании. Начиная с версии 26.10, минимальной является Java 8, а Java 6 и Java 7 больше не поддерживаются.
{{% /alert %}}

Проект Maven и команды в [Installation](/slides/ru/java/installation/) требуют JDK 11 или выше. С Java 8 компилируйте и запускайте программу, как показано в [Check Your Setup](#check-your-setup).

## **Поддерживаемые операционные системы**

Поскольку файл JAR не содержит нативного кода, Aspose.Slides for Java работает в Windows, Linux и macOS, на любой архитектуре процессора, поддерживаемой средой выполнения Java, такой как x64 и ARM64. На Windows единственное требование — среда выполнения Java. На Linux поддержка шрифтов Java также требует библиотеку шрифтов и шрифты, описанные в [Linux](#linux).

## **Linux**

Aspose.Slides for Java разметивает и рисует текст с использованием поддержки шрифтов среды выполнения Java. На Linux эта поддержка требует библиотеку fontconfig и как минимум один установленный шрифт. Официальные образы контейнеров Linux‑дистрибутивов часто не содержат их. Без этих компонентов первый пример в [Create Presentations](/slides/ru/java/create-presentation/) падает при сохранении презентации, оставляя пустой файл и выдавая следующую ошибку:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Официальные образы контейнеров `eclipse-temurin` для Ubuntu и Alpine Linux уже включают fontconfig и шрифты DejaVu, поэтому ничего дополнительно устанавливать не требуется. На остальных системах установите перечисленные ниже пакеты. Команды для Debian, Ubuntu и Red Hat используют `sudo`; в Dockerfile выполните их в инструкции `RUN` без `sudo`. Шрифты DejaVu достаточны для работы Aspose.Slides; шрифты, используемые вашими презентациями, описаны в разделе [Fonts](#fonts).

### **Debian и Ubuntu**

Если вы устанавливаете Java из пакетов Debian или Ubuntu с настройками `apt-get` по умолчанию, как делает команда в [Installation](/slides/ru/java/installation/#linux), пакеты Java также ставят библиотеку fontconfig, шрифты DejaVu и библиотеку HarfBuzz, нужную этим пакетам, и ничего более не требуется.

С Java‑средой из другого источника, например из архива Eclipse Temurin, установите fontconfig и шрифты DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile часто устанавливает пакеты Java из Debian или Ubuntu, такие как `openjdk-21-jdk-headless` или `default-jdk-headless`, с опцией `--no-install-recommends`, которая пропускает все три. Установите fontconfig и шрифты DejaVu командой выше, а также HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Без HarfBuzz эти пакеты Java выводят `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, а сохранение завершается ошибкой `UnsatisfiedLinkError`, сообщающей, что `libharfbuzz.so.0` нельзя открыть.

### **Red Hat Enterprise Linux**

Пакеты `java-<version>-openjdk-headless` в Red Hat Enterprise Linux не устанавливают библиотеку fontconfig. Установите её вместе с шрифтами DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Полные пакеты `java-<version>-openjdk` устанавливают fontconfig и шрифты как зависимости, так же как и пакеты Amazon Corretto для Amazon Linux 2023, например `java-21-amazon-corretto-headless`.

### **Alpine Linux**

В Dockerfile, основанном на Alpine Linux, установите fontconfig и шрифты DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

В текущих выпусках Alpine пакет `ttf-dejavu` ставит пакет `font-dejavu`. Установите Java через пакет `openjdk<version>-jre` или `openjdk<version>-jdk`, например `openjdk25-jdk`. Пакеты `openjdk<version>-jre-headless` в Alpine не содержат библиотеку шрифтов Java, поэтому программа падает с `UnsatisfiedLinkError: no fontmanager in system library path`, даже если шрифты установлены.

### **Шрифты**

Чтобы текст отображался правильными шрифтами и метриками, шрифты, используемые вашими презентациями, или подходящие заменители, должны быть установлены в системе или загружены вашим приложением. См. [Deploy Fonts](/slides/ru/java/deploy-fonts/), [Font Substitution](/slides/ru/java/font-substitution/) и [Custom Fonts](/slides/ru/java/custom-font/).

## **Проверьте настройку**

Чтобы убедиться, что библиотека и её зависимости находятся на месте, запустите программу, сохраняющую презентацию и рендерящую слайд в изображение. Сохранение и рендеринг используют поддержку шрифтов среды выполнения Java, которую обеспечивают вышеописанные требования для Linux.

Сохраните код ниже как *CheckSetup.java* в папке, где находится JAR‑файл Aspose.Slides. Чтобы скачать JAR‑файл, см. [Use the JAR File without Maven](/slides/ru/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Добавляем прямоугольник с текстом на первый слайд и сохраняем презентацию.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Рендерим слайд с одним пикселем на пункт и сохраняем изображение.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

С JDK 11 и выше запустите программу в этой папке командой ниже. Если ваш JAR‑файл имеет другое имя, замените его в командах.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

С Java 8 или если в системе только JRE, скомпилируйте программу `javac` из JDK, а затем запустите скомпилированный класс. В Linux и macOS выполните:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

В Windows выполните ту же команду `javac`, а затем запустите класс, используя точку с запятой как разделитель путей классов. Сохраните кавычки, чтобы PowerShell не воспринял точку с запятой как конец команды: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

Программа добавляет прямоугольник с текстом на первый слайд и сохраняет презентацию как *hello.pptx* методом [save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Затем она рендерит слайд с помощью [getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/#getImage-float-float-) и сохраняет результат как *hello.png* через [IImage.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/#save-java.lang.String-int-) в формате [ImageFormat.Png](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imageformat/). Коэффициент масштабирования 1 отображает один пиксел на пункт, так что слайд размером по умолчанию 720 × 540 пунктов превращается в изображение 720 × 540 пикселей, с видимым текстом внутри прямоугольника. Без лицензии оба файла содержат тестовую водяную метку; см. [Licensing](/slides/ru/java/licensing/). Если какое‑либо требование отсутствует, программа завершается одной из ошибок, описанных в разделе [Linux](#linux).

## **Инструменты разработки**

Вы можете создавать приложения, использующие Aspose.Slides, с любой JDK поддерживаемой версии Java. Используйте Apache Maven с Maven‑репозиторием Aspose, как описано в [Installation](/slides/ru/java/installation/), или любой другой инструмент сборки, способный работать с Maven‑репозиторием. Вы также можете вручную добавить JAR‑файл в classpath вашей IDE или инструмента сборки.

## **FAQ**

**Нужен ли установленный Microsoft PowerPoint для конвертации и рендеринга?**

Нет, PowerPoint не требуется. Aspose.Slides — это автономный движок для [создания](/slides/ru/java/create-presentation/), изменения, [конвертации](/slides/ru/java/convert-presentation/) и [рендеринга](/slides/ru/java/convert-powerpoint-to-png/) презентаций.

**Нужен ли Aspose.Slides for Java дисплей или графическая среда на Linux‑сервере?**

Нет. Aspose.Slides не требует X‑сервера или дисплея, поэтому работает на серверах и в контейнерах. На Linux ему нужна только библиотека шрифтов и шрифты, описанные в разделе [Linux](#linux).

**Какие шрифты нужны для корректного рендеринга?**

Шрифты, использованные в презентации, или подходящие [заменители](/slides/ru/java/font-substitution/), должны быть доступны. В Linux и macOS установите пакеты шрифтов, необходимые вашим презентациям, чтобы обеспечить единообразный рендеринг.

**Почему пользовательский шрифт отображается как запасной или пропущенный текст в Linux?**

Если файл шрифта содержит несовместимые или повреждённые записи в таблице имён, стек сопоставления шрифтов Linux (FreeType/fontconfig) может выбрать неверный рекорд, из‑за чего шрифт остаётся неразрешённым. Использование версии шрифта с исправленными записями таблицы имён или установка согласованного заменителя решает проблему.