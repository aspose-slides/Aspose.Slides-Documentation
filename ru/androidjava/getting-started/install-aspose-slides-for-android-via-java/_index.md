---
title: Установка Aspose.Slides для Android через Java
type: docs
weight: 90
url: /ru/androidjava/install-aspose-slides-for-android-via-java/
---




## **Установка**
Ранее Aspose.Slides для Android через Java распространялся в виде одного ZIP-файла, содержащего JAR-файл, демонстрационные примеры и документацию по продукту. 

1. Если вы хотите использовать версию старше Aspose.Words для Android через Java 18.9, вам необходимо разархивировать эту версию Aspose.Slides.Android.zip в вашу предпочитаемую директорию. 
1. Добавьте извлеченный Jar файл в ваше приложение, используя конфигурацию Build Path. 
### **Добавление ссылки на Aspose.Slides для Android через Java Jar**
1. Скачайте последнюю версию [Aspose.Slides для Android через Java](https://downloads.aspose.com/slides/androidjava)
1. Скопируйте aspose-slides-18.9-android.via.java.jar в папку *libs/*вашего проекта

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Установка Aspose.Slides для Android через Java из Maven Repository**
1. Добавьте репозиторий maven в ваш build.gradle. 
1. Добавьте [Aspose.Slides для Android через Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) JAR в качестве зависимости.

``` java

 // 1. Добавьте репозиторий maven в ваш build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Добавьте 'Aspose.Slides для Android через Java' JAR в качестве зависимости

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```
## **Ваше Первое Приложение Использующее Aspose.Slides для Android через Java**
В этом разделе вы узнаете, как начать работать с Aspose.Slides для Android через Java. Мы намерены показать вам, как создать новый проект Android с нуля, добавить ссылку на JAR Aspose.Slides и создать новую презентацию PowerPoint, которая будет сохранена на диск в формате PPTX. В этом примере используется [Android Studio](https://developer.android.com/studio/index.html) для разработки, а приложение запускается на эмуляторе Android. Чтобы начать работу с Aspose.Slides для Android через Java, следуйте этому пошаговому руководству, чтобы создать приложение, использующее Aspose.Slides для Android через Java:

1. Скачайте [Android Studio](https://developer.android.com/studio/index.html) и установите его в любое место.
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




1. Выберите раздел Project (в меню файла) и нажмите на вкладку Dependencies.
   1. Нажмите на кнопку "+". Выберите опцию зависимости файла.
   1. Выберите библиотеку Aspose.Slides из папки libs и нажмите OK.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. При необходимости синхронизируйте проект с файлами gradle. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. Чтобы получить доступ к SD-карте, необходимо добавить специальные разрешения. Нажмите на файл AndroidManifest.xml и выберите XML-вид. Добавьте эту строку в файл <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. Вернитесь к коду приложения и добавьте эти импорты: 

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

Теперь вставьте этот код в тело метода onCreate, чтобы создать новую презентацию с нуля, используя Aspose.Slides и сохранить ее на SD-карте в формате PPTX.

``` java

 try

{

    // Создаем класс Presentation, который представляет PPTX

    Presentation pres = new Presentation();



    // Доступ к первому слайду

    ISlide sld = pres.getSlides().get_Item(0);



    // Добавляем AutoShape типа Rectangle

    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // Добавляем TextFrame к прямоугольнику

    ashp.addTextFrame(" ");



    // Доступ к текстовому фрейму

    ITextFrame txtFrame = ashp.getTextFrame();



    // Создаем объект Paragraph для текстового фрейма

    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // Создаем объект Portion для параграфа

    IPortion portion = para.getPortions().get_Item(0);



    // Устанавливаем текст

    portion.setText("Aspose TextBox");



    // Сохраняем PPTX на карте

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



1. Теперь запустите приложение снова. На этот раз код Aspose.Slides будет выполняться в фоновом режиме и создаст документ, который будет сохранен на SD-карте.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Чтобы просмотреть созданный документ, перейдите в меню Tools. Выберите Android, а затем выберите Android Device Monitor

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Версионирование**
С 2018 года версионирование Aspose.Slides для Android через Java соответствует Aspose.Slides для Java. 