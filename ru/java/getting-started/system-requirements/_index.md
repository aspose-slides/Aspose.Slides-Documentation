---
title: Требования к системе
type: docs
weight: 60
url: /ru/java/system-requirements/
keywords:
- требования к системе
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
description: "Проверьте, что требуется Aspose.Slides for Java перед установкой: поддерживаемые версии Java и операционные системы, а также библиотека шрифтов и шрифты, необходимые в Linux."
---
## **Введение**

Aspose.Slides for Java — это отдельная библиотека: она не требует Microsoft PowerPoint или Microsoft Office. Это один файл JAR, опубликованный в Maven‑репозитории Aspose. Файл JAR содержит только Java‑классы и ресурсы, без нативных библиотек, и не объявляет зависимостей от других библиотек. Поэтому один и тот же файл работает на любой операционной системе и процессоре, для которых доступна поддерживаемая Java‑runtime.

В этой статье перечислены поддерживаемые версии Java и операционные системы, а также библиотека шрифтов и шрифты, необходимые в Linux, и в конце приведён небольшой пример программы, проверяющей вашу конфигурацию. Чтобы добавить библиотеку в проект, см. [Установка](/slides/ru/java/installation/).

## **Поддерживаемые версии Java**

Aspose.Slides for Java работает на Java 8 и выше, с JDK или JRE. Это включает версии с длительной поддержкой Java 8, 11, 17, 21 и 25, а также более новые, такие как Java 26 и Java 27. Java‑runtime может быть любой поставки, например Eclipse Temurin, Amazon Corretto, Oracle или пакеты OpenJDK дистрибутива Linux.

Aspose.Slides не требует никаких параметров JVM, таких как `--add-opens`, на любой из этих версий. На Java 11 JVM выводит предупреждение, начинающееся с «WARNING: An illegal reflective access operation has occurred»; это предупреждение не влияет на результат.

{{% alert color="warning" title="Warning" %}}
Java 6 и Java 7 устарели. Aspose.Slides for Java 26.9 всё ещё работает с ними, но выводит предупреждение об устаревании. Начиная с версии 26.10, минимальной становится Java 8, а поддержка Java 6 и Java 7 прекращена.
{{% /alert %}}

Проекты Maven и команды в [Установка](/slides/ru/java/installation/) требуют JDK 11 или новее. При работе с Java 8 компилируйте и запускайте программу, как показано в разделе [Проверьте свою конфигурацию](#check-your-setup).

## **Поддерживаемые операционные системы**

Поскольку файл JAR не содержит нативного кода, Aspose.Slides for Java работает на Windows, Linux и macOS, на любой архитектуре процессора, поддерживаемой Java‑runtime, например x64 и ARM64. На Windows требуется только Java‑runtime. На Linux дополнительно требуется библиотека шрифтов и шрифты, описанные в разделе [Linux](#linux).

## **Linux**

Aspose.Slides for Java размещает и рисует текст с использованием поддержки шрифтов Java‑runtime. В Linux эта поддержка требует библиотеку fontconfig и хотя бы один установленный шрифт. Официальные контейнерные образы дистрибутивов Linux часто не включают их. Без этих компонентов первый пример в [Создание презентаций](/slides/ru/java/create-presentation/) завершится ошибкой при сохранении презентации, оставив пустой файл и сообщив об ошибке:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Официальные контейнерные образы `eclipse-temurin` для Ubuntu и Alpine Linux уже содержат fontconfig и шрифты DejaVu, поэтому дополнительные установки не требуются. На других системах установите перечисленные ниже пакеты. Команды для Debian, Ubuntu и Red Hat используют `sudo`; в Dockerfile их следует выполнять в инструкции `RUN` без `sudo`. Шрифты DejaVu достаточно для работы Aspose.Slides; шрифты, используемые в ваших презентациях, описаны в разделе [Шрифты](#fonts).

### **Debian и Ubuntu**

Если вы устанавливаете Java из пакетов Debian или Ubuntu с настройками `apt-get` по умолчанию, как в команде из [Установка](/slides/ru/java/installation/#linux), пакеты Java также установят библиотеку fontconfig, шрифты DejaVu и библиотеку HarfBuzz, необходимые этим пакетам, и ничего более не требуется.

С Java‑runtime из другого источника, например из архива Eclipse Temurin, установите fontconfig и шрифты DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile часто устанавливает пакеты Java Debian или Ubuntu, такие как `openjdk-21-jdk-headless` или `default-jdk-headless`, с опцией `--no-install-recommends`, которая пропускает все три. Установите fontconfig и шрифты DejaVu командой выше, а также HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Без HarfBuzz эти пакеты Java выводят `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, и сохранение завершается `UnsatisfiedLinkError`, указывающим, что `libharfbuzz.so.0` не может быть открыта.

### **Red Hat Enterprise Linux**

Пакеты `java-<version>-openjdk-headless` в Red Hat Enterprise Linux не устанавливают библиотеку fontconfig. Установите её вместе с шрифтами DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Полные пакеты `java-<version>-openjdk` устанавливают fontconfig и шрифты как зависимости, так же как пакеты Amazon Corretto для Amazon Linux 2023, например `java-21-amazon-corretto-headless`.

### **Alpine Linux**

В Dockerfile на базе Alpine Linux установите fontconfig и шрифты DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

В текущих релизах Alpine `ttf-dejavu` устанавливает пакет `font-dejavu`. Установите Java пакетом `openjdk<version>-jre` или `openjdk<version>-jdk`, например `openjdk25-jdk`. Пакеты `openjdk<version>-jre-headless` в Alpine не содержат библиотеку шрифтов Java, поэтому программа завершается `UnsatisfiedLinkError: no fontmanager in system library path`, даже если шрифты установлены.

### **Шрифты**

Чтобы текст отображался правильными шрифтами и метриками, шрифты, используемые в ваших презентациях, или подходящие заменители, должны быть установлены в системе или загружены вашим приложением. Смотрите [Развёртывание шрифтов](/slides/ru/java/deploy-fonts/), [Замена шрифтов](/slides/ru/java/font-substitution/) и [Пользовательские шрифты](/slides/ru/java/custom-font/).

## **Проверьте свою конфигурацию**

Чтобы убедиться, что библиотека и её требования выполнены, запустите программу, сохраняющую презентацию и рендерящую слайд в изображение. Сохранение и рендеринг используют поддержку шрифтов Java‑runtime, которую обеспечивают перечисленные выше требования для Linux.

Сохраните приведённый ниже код как *CheckSetup.java* в папке, где находится JAR‑файл Aspose.Slides. Чтобы загрузить JAR‑файл, см. [Использование JAR‑файла без Maven](/slides/ru/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Добавьте прямоугольник с текстом на первый слайд и сохраните презентацию.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Отрисуйте слайд один пиксель на пункт и сохраните изображение.
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

С JDK 11 и новее выполните программу в этой папке командой ниже. Если ваш JAR‑файл имеет другое имя, замените его в командах.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

С Java 8 или на системе, где установлен только JRE, скомпилируйте программу `javac` из JDK, а затем запустите скомпилированный класс. В Linux и macOS выполните:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

В Windows выполните ту же команду `javac`, а затем запустите класс, используя точку с запятой как разделитель путей к классам. Сохраните кавычки, чтобы PowerShell не воспринимал точку с запятой как конец команды: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Программа добавляет прямоугольник с текстом на первый слайд и сохраняет презентацию как *hello.pptx* с помощью метода [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Затем она рендерит слайд с помощью [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) и сохраняет результат как *hello.png* с помощью [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) в формате [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). Коэффициенты масштабирования 1 отображают один пиксель на пункт, поэтому слайд 720 × 540 point превращается в изображение 720 × 540 pixel, с видимым текстом внутри прямоугольника. Без лицензии оба файла помечаются водяным знаком оценки; см. [Лицензирование](/slides/ru/java/licensing/). Если какое‑то требование не выполнено, программа останавливается одной из ошибок, описанных в разделе [Linux](#linux).

## **Инструменты разработки**

Вы можете создавать приложения, использующие Aspose.Slides, с любой JDK поддерживаемой версии Java. Используйте Apache Maven с Maven‑репозиторием Aspose, как описано в [Установка](/slides/ru/java/installation/), или любой другой инструмент сборки, способный работать с Maven‑репозиторием. JAR‑файл также можно добавить в classpath вашей IDE или инструмента сборки вручную.

## **FAQ**

**Нужен ли установленный Microsoft PowerPoint для конвертации и рендеринга?**

Нет, PowerPoint не требуется. Aspose.Slides — это автономный движок для [создания](/slides/ru/java/create-presentation/), изменения, [конвертации](/slides/ru/java/convert-presentation/) и [рендеринга](/slides/ru/java/convert-powerpoint-to-png/) презентаций.

**Требуется ли дисплей или рабочая среда на Linux‑сервере?**

Нет. Aspose.Slides не нуждается в X‑сервере или дисплее, поэтому работает на серверах и в контейнерах. В Linux требуются только библиотека шрифтов и шрифты, описанные в разделе [Linux](#linux).

**Какие шрифты нужны для корректного рендеринга?**

Шрифты, использованные в презентации, или подходящие [заменители](/slides/ru/java/font-substitution/), должны быть доступны. В Linux и macOS установите пакеты шрифтов, необходимые вашим презентациям, чтобы обеспечить единообразный рендеринг.

**Почему пользовательский шрифт отображается как запасной или отсутствующий текст в Linux?**

Если в файле шрифта есть неконсистентные или повреждённые записи таблицы имён, стек сопоставления шрифтов Linux (FreeType/fontconfig) может выбрать недействительную запись, из‑за чего шрифт остаётся нераспознанным. Использование версии шрифта с исправленными записями таблицы имён или установка согласующей замены решает проблему.