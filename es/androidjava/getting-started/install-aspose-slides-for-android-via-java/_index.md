---
title: Instalar Aspose.Slides para Android vía Java
type: docs
weight: 90
url: /es/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- instalar Aspose.Slides
- descargar Aspose.Slides
- usar Aspose.Slides
- instalación de Aspose.Slides
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Instale rápidamente Aspose.Slides para Android. Guía paso a paso, requisitos del sistema y ejemplos de código Java — ¡comience a trabajar con presentaciones PowerPoint hoy!"
---

## **Instalación**
Anteriormente, Aspose.Slides for Android via Java se distribuía como un único archivo ZIP que contenía el archivo JAR, demostraciones y la documentación del producto. 

1. Si desea usar una versión anterior a Aspose.Words for Android via Java 18.9, debe descomprimir esa versión de Aspose.Slides.Android.zip en el directorio que prefiera. 
2. Añada el archivo JAR extraído a su aplicación usando la configuración Build Path. 
### **Agregar una referencia a Aspose.Slides for Android via Java Jar**
1. Descargue la versión más reciente de [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/androidjava)
2. Copie aspose-slides-18.9-android.via.java.jar a la carpeta *libs/* de su proyecto

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Instalar Aspose.Slides for Android via Java desde el repositorio Maven**
1. Añada el repositorio Maven a su build.gradle. 
2. Añada el JAR de [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) como una dependencia.
``` java

 // 1. Añadir repositorio Maven en su build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Añadir 'Aspose.Slides for Android via Java' JAR como dependencia

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```

## **Su primera aplicación usando Aspose.Slides for Android via Java**
En esta sección aprenderá cómo empezar con Aspose.Slides for Android via Java. Pretendemos mostrarle cómo crear un nuevo proyecto Android desde cero, agregar una referencia al JAR de Aspose.Slides y crear una nueva presentación PowerPoint que se guardará en el disco en formato PPTX. El ejemplo utiliza [Android Studio](https://developer.android.com/studio/index.html) para el desarrollo y la aplicación se ejecuta en el Emulador de Android. Para comenzar con Aspose.Slides for Android via Java, siga este tutorial paso a paso para crear una aplicación que use Aspose.Slides for Android via Java:

1. Descargue e instale [Android Studio](https://developer.android.com/studio/index.html) en cualquier ubicación. 
2. Ejecute Android Studio. 
3. Cree un nuevo proyecto de aplicación Android. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. Copie aspose-slides-XX.XX-android.via.java.jar a la carpeta libs/ de su proyecto

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. Seleccione **Project Section** (desde el menú Archivo) y haga clic en la pestaña **Dependencies**.  
   1. Pulse el botón “+”. Seleccione la opción de dependencia de archivo.  
   2. Seleccione la biblioteca Aspose.Slides desde la carpeta libs y haga clic en **OK**.  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. Sincronice el proyecto con los archivos gradle si es necesario.  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. Para acceder a la tarjeta SD, se deben agregar permisos especiales. Abra el archivo AndroidManifest.xml y elija la vista XML. Añada la siguiente línea al archivo <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. Regrese a la sección de código de la aplicación y añada estas instrucciones import: 
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


Ahora, inserte este código en el cuerpo del método onCreate para crear una nueva Presentation desde cero usando Aspose.Slides y guardarla en la tarjeta SD en formato PPTX.  
``` java
 try
{
    // Instanciar la clase Presentation que representa un PPTX
    Presentation pres = new Presentation();

    // Acceder a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar un AutoShape de tipo Rectángulo
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



1. Ejecute nuevamente la aplicación. Esta vez, el código de Aspose.Slides se ejecutará en segundo plano y generará un documento que se guardará en la tarjeta SD.  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Para visualizar el documento creado, vaya al menú Tools, elija Android y luego seleccione Android Device Monitor  

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Versionado**
Desde 2018, el versionado de Aspose.Slides for Android via Java cumple con el de Aspose.Slides for Java. 

## **Preguntas frecuentes**

**¿Cómo puedo verificar que Aspose.Slides está integrado correctamente?**

Compile su proyecto, instancie una [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) en blanco y guárdela con un nombre nuevo. Si el archivo se crea sin lanzar excepciones, la biblioteca se ha integrado con éxito.

**¿Cómo puedo limitar el consumo de memoria al procesar presentaciones grandes?**

Aumente los límites de memoria de la JVM solo tanto como sea necesario y cierre cada instancia de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) en un `finally` para liberar la caché de inmediato. Esto evita errores de falta de memoria y mantiene el uso total de memoria predecible durante operaciones por lotes.

**¿Puedo excluir formatos de exportación no deseados para reducir el tamaño final del JAR?**

Las versiones actuales de Aspose.Slides se distribuyen como una única biblioteca monolítica, por lo que no es posible desactivar exportadores específicos como PDF o SVG en tiempo de compilación.