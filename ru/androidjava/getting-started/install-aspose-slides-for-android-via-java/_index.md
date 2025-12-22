---
title: Установить Aspose.Slides для Android через Java
type: docs
weight: 90
url: /ru/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- установить Aspose.Slides
- скачать Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Быстрая установка Aspose.Slides для Android. Пошаговое руководство, системные требования и примеры кода на Java — начните работать с презентациями PowerPoint уже сегодня!"
---

## **Установка**
Ранее Aspose.Slides for Android via Java распространялся как один ZIP‑файл, содержащий JAR‑файл, демо‑версии и документацию продукта. 

1. Если вам требуется использовать версию старше Aspose.Words for Android via Java 18.9, необходимо распаковать соответствующий файл Aspose.Slides.Android.zip в выбранный каталог. 
1. Добавьте извлечённый JAR‑файл в приложение, используя конфигурацию Build Path. 
### **Добавить ссылку на Aspose.Slides for Android via Java Jar**
1. Скачайте последнюю версию [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/androidjava)
1. Скопируйте aspose-slides-18.9-android.via.java.jar в папку *libs/* вашего проекта

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Установить Aspose.Slides for Android via Java из Maven‑репозитория**
1. Добавьте репозиторий Maven в ваш build.gradle. 
1. Добавьте JAR [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) в качестве зависимости.
``` java

 // 1. Добавьте репозиторий Maven в ваш build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Добавьте JAR 'Aspose.Slides for Android via Java' в качестве зависимости

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}
```

## **Ваше первое приложение, использующее Aspose.Slides for Android via Java**
В этом разделе вы узнаете, как начать работу с Aspose.Slides for Android via Java. Мы покажем, как создать новый Android‑проект с нуля, добавить ссылку на JAR‑файл Aspose.Slides и создать новую презентацию PowerPoint, сохраняемую на диск в формате PPTX. В примере используется [Android Studio](https://developer.android.com/studio/index.html) для разработки, а приложение запускается в Android Emulator. Чтобы приступить к работе с Aspose.Slides for Android via Java, следуйте этому пошаговому руководству по созданию приложения, использующего Aspose.Slides for Android via Java:

1. Скачайте [Android Studio](https://developer.android.com/studio/index.html) и установите его в любое место.
1. Запустите Android Studio.
1. Создайте новый проект Android Application.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. Скопируйте aspose-slides-XX.XX-android.via.java.jar в папку libs вашего проекта

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. Выберите раздел Project (в меню File) и перейдите на вкладку Dependencies.
   1. Нажмите кнопку «+». Выберите вариант зависимости от файла.
   1. Выберите библиотеку Aspose.Slides из папки libs и нажмите OK.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. При необходимости синхронизируйте проект с gradle‑файлами. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. Чтобы получить доступ к SD‑карте, необходимо добавить специальные разрешения. Откройте файл AndroidManifest.xml и выберите режим XML. Добавьте в файл следующую строку <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. Перейдите обратно к разделу кода приложения и добавьте эти директивы using: 
``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment; 

```


Теперь вставьте этот код в тело метода onCreate, чтобы создать новую Presentation с нуля с использованием Aspose.Slides и сохранить её на SD‑карту в формате PPTX.
``` java

 try
{
    // Создать экземпляр класса Presentation, представляющего PPTX
    Presentation pres = new Presentation();

    // Получить первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Добавить AutoShape типа Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Добавить TextFrame к прямоугольнику
    ashp.addTextFrame(" ");

    // Получение text frame
    ITextFrame txtFrame = ashp.getTextFrame();

    // Создать объект Paragraph для text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Создать объект Portion для абзаца
    IPortion portion = para.getPortions().get_Item(0);

    // Установить текст
    portion.setText("Aspose TextBox");

    // Сохранить PPTX на карту
    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;
    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);
}
catch (Exception e)
{
   e.printStackTrace();
}
```


Полный код должен выглядеть так:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)



1. Теперь снова запустите приложение. На этот раз код Aspose.Slides выполнится в фоновом режиме и сгенерирует документ, сохраняемый на SD‑карту.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Чтобы просмотреть созданный документ, откройте меню Tools, выберите Android, а затем Android Device Monitor

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Версионирование**
С 2018 года система версионирования Aspose.Slides for Android via Java соответствует Aspose.Slides for Java. 

## **FAQ**

**Как я могу проверить, что Aspose.Slides интегрирован корректно?**

Соберите проект, создайте пустой объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и сохраните его под новым именем. Если файл создаётся без исключений, библиотека успешно интегрирована.

**Как я могу ограничить потребление памяти при обработке больших презентаций?**

Увеличивайте лимиты памяти JVM только до необходимого уровня и закрывайте каждый экземпляр [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) в блоке `finally`, чтобы своевременно освобождать кэш. Это предотвращает ошибки недостатка памяти и обеспечивает предсказуемое использование памяти при пакетных операциях.

**Могу ли я исключить нежелательные форматы экспорта, чтобы уменьшить конечный размер JAR?**

Текущие выпуски Aspose.Slides поставляются в виде единой монолитной библиотеки, поэтому отключить отдельные экспортеры, такие как PDF или SVG, во время сборки невозможно.