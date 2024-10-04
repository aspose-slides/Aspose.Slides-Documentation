---
title: Instalar Aspose.Slides para Android a través de Java
type: docs
weight: 90
url: /es/androidjava/install-aspose-slides-for-android-via-java/
---




## **Instalación**
Anteriormente, Aspose.Slides para Android a través de Java se distribuía como un solo archivo ZIP que contenía el archivo JAR, demostraciones y la documentación del producto.

1. Si deseas usar una versión anterior a Aspose.Words para Android a través de Java 18.9, necesitas descomprimir esa versión de Aspose.Slides.Android.zip en tu directorio preferido. 
1. Agrega el archivo Jar extraído en tu aplicación utilizando la configuración de Build Path. 
### **Agregar referencia a Aspose.Slides para Android a través de Java Jar**
1. Descarga la versión más reciente de [Aspose.Slides para Android a través de Java](https://downloads.aspose.com/slides/androidjava)
1. Copia aspose-slides-18.9-android.via.java.jar en la carpeta *libs/* de tu proyecto

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Instalar Aspose.Slides para Android a través de Java desde el repositorio de Maven**
1. Agrega el repositorio de Maven en tu build.gradle. 
1. Agrega el JAR de [Aspose.Slides para Android a través de Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) como una dependencia.

``` java

 // 1. Agrega el repositorio de Maven en tu build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Agrega el JAR de 'Aspose.Slides para Android a través de Java' como una dependencia

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```
## **Tu primera aplicación usando Aspose.Slides para Android a través de Java**
En esta sección, aprenderás a comenzar con Aspose.Slides para Android a través de Java. Nuestro objetivo es mostrarte cómo configurar un nuevo proyecto de Android desde cero, agregar una referencia al JAR de Aspose.Slides y crear una nueva presentación de PowerPoint que se guarda en el disco en formato PPTX. El ejemplo aquí utiliza [Android Studio](https://developer.android.com/studio/index.html) para el desarrollo y la aplicación se ejecuta en el emulador de Android. Para comenzar con Aspose.Slides para Android a través de Java, sigue este tutorial paso a paso para crear una aplicación que use Aspose.Slides para Android a través de Java:

1. Descarga [Android Studio](https://developer.android.com/studio/index.html) y instala en cualquier ubicación.
1. Ejecuta Android Studio.
1. Crea un nuevo proyecto de aplicación de Android.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. Copia aspose-slides-XX.XX-android.via.java.jar en la carpeta libs/ de tu proyecto

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. Selecciona la sección de Proyecto (desde el menú de archivo) y haz clic en la pestaña de Dependencias.
   1. Haz clic en el botón "+" y selecciona la opción de dependencia de archivo.
   1. Selecciona la biblioteca Aspose.Slides de la carpeta libs y haz clic en Aceptar.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. Sincroniza el proyecto con los archivos de gradle si es necesario. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. Para acceder a la tarjeta SD, se deben agregar permisos especiales. Haz clic en el archivo AndroidManifest.xml y elige la vista XML. Agrega esta línea al archivo <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. Navega de nuevo a la sección de código de la aplicación y agrega estas importaciones: 

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

Ahora, inserta este código en el cuerpo del método onCreate para crear una nueva Presentación desde cero utilizando Aspose.Slides y guardarla en la tarjeta SD en formato PPTX.

``` java

 try

{

    // Instanciar la clase Presentation que representa PPTX

    Presentation pres = new Presentation();



    // Acceder a la primera diapositiva

    ISlide sld = pres.getSlides().get_Item(0);



    // Agregar una forma automática de tipo Rectángulo

    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // Agregar un TextFrame al Rectángulo

    ashp.addTextFrame(" ");



    // Accediendo al marco de texto

    ITextFrame txtFrame = ashp.getTextFrame();



    // Crear el objeto Paragraph para el marco de texto

    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // Crear el objeto Portion para el párrafo

    IPortion portion = para.getPortions().get_Item(0);



    // Establecer texto

    portion.setText("Aspose TextBox");



    // Guardar el PPTX en la tarjeta

    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;

    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);

}

catch (Exception e)

{

   e.printStackTrace();

}

```

El código completo debería verse así:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)



1. Ahora ejecuta la aplicación nuevamente. Esta vez, el código de Aspose.Slides se ejecutará en segundo plano y generará un documento que se guardará en la tarjeta SD.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Para ver el documento creado, navega al menú Herramientas. Selecciona Android y luego elige Monitoreo de Dispositivos Android

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Versionado**
Desde 2018, el versionado de Aspose.Slides para Android a través de Java cumple con Aspose.Slides para Java.