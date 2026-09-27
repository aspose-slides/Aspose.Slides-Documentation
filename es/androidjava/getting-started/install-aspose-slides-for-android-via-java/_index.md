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
- Gradle
- repositorio Maven
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Agrega Aspose.Slides para Android vía Java a un proyecto Android Studio con Gradle desde el repositorio Maven de Aspose, o añade el archivo JAR manualmente."
---
## **Visión general**

Este artículo explica cómo agregar Aspose.Slides for Android via Java a un proyecto Android. La forma recomendada es permitir que Gradle descargue la biblioteca desde el repositorio Maven de Aspose. También puedes descargar el archivo JAR y añadirlo a tu proyecto manualmente.

La biblioteca no está publicada en Maven Central ni en el repositorio Maven de Google. Está disponible en el propio repositorio de Aspose, como el artefacto `aspose-slides` con el clasificador `android.via.java`.

## **Instalar desde el repositorio Maven de Aspose**

### **Paso 1: Añadir el repositorio**

Los proyectos nuevos de Android Studio declaran sus repositorios en el bloque `dependencyResolutionManagement` de *settings.gradle.kts*, y Gradle rechaza los repositorios que añada el archivo de compilación de un módulo. Añade la línea `maven` que se muestra a continuación al bloque `repositories` dentro de ese bloque existente, en lugar de pegar un segundo bloque `dependencyResolutionManagement`:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **Paso 2: Añadir la dependencia**

Añade la biblioteca al bloque `dependencies` del archivo de compilación del módulo de la aplicación, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

La última parte de las coordenadas, `android.via.java`, es el clasificador que selecciona la compilación Android de la biblioteca. Sin él, Gradle no puede encontrar el artefacto.

A continuación sincroniza el proyecto con los archivos Gradle, de modo que Gradle descargue la biblioteca.

### **Elegir una versión**

Aspose.Slides for Android via Java no se construye para todas las versiones del repositorio. Sus compilaciones se publican solo para algunas versiones de Aspose.Slides for Java, y una versión sin compilación Android no se resuelve. Elige una versión que aparezca en la [página de descarga de Aspose.Slides for Android via Java](https://releases.aspose.com/slides/es/androidjava/).

### **Scripts de compilación Groovy**

Si tu proyecto utiliza scripts de compilación Groovy, añade la línea `maven` al bloque `repositories` dentro del bloque `dependencyResolutionManagement` existente de *settings.gradle*:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

Y añade la dependencia a *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Añadir el archivo JAR manualmente**

Si no puedes usar un repositorio Maven, añade el archivo JAR a tu proyecto:

1. Descarga el archivo JAR desde la carpeta de la versión en el [repositorio Maven de Aspose](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Para la versión 26.9, el archivo es *aspose-slides-26.9-android.via.java.jar* en la carpeta *26.9*.
1. Copia el archivo en la carpeta *app/libs* de tu proyecto. Crea la carpeta si no existe.
1. Añade el archivo al bloque `dependencies` de *app/build.gradle.kts*, luego sincroniza el proyecto:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Crear tu primera presentación**

Una vez que el proyecto se haya sincronizado, continúa con [Create Presentations](/slides/es/androidjava/create-presentation/). Su primer ejemplo agrega un cuadro de texto a una diapositiva y guarda la presentación en el almacenamiento privado de tu aplicación, sin necesidad de permiso de almacenamiento. Sin una licencia, Aspose.Slides agrega una marca de agua de evaluación a cada diapositiva que guarda; consulta [Licensing](/slides/es/androidjava/licensing/).

## **Control de versiones**

Desde 2018, el control de versiones de Aspose.Slides for Android via Java se ha alineado con Aspose.Slides for Java. Las compilaciones Android no se publican para cada versión Java; consulta [Elegir una versión](#choose-a-version).

## **Preguntas frecuentes**

### ¿Cómo puedo comprobar que Aspose.Slides está integrado correctamente?

Compila tu proyecto, instancia una [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) vacía y guárdala con un nombre nuevo. Si el archivo se crea sin lanzar excepciones, la biblioteca se ha integrado con éxito.

### ¿Cómo puedo limitar el consumo de memoria al procesar presentaciones grandes?

Llama al método [dispose](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#dispose--) de cada instancia de [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) dentro de un bloque `finally` para liberar sus recursos de inmediato, y procesa una presentación grande a la vez. Esto ayuda a prevenir errores de falta de memoria y mantiene predecible el uso total de memoria durante operaciones por lotes.

### ¿Puedo excluir formatos de exportación no deseados para reducir el tamaño final del JAR?

Las versiones actuales de Aspose.Slides se entregan como una única biblioteca monolítica, por lo que no puedes desactivar exportadores específicos como PDF o SVG en tiempo de compilación.