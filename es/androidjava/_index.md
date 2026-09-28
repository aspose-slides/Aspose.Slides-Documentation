---
title: Aspose.Slides for Android via Java
second_title: Aspose.Slides for Android
type: docs
weight: 40
url: /es/androidjava/
keywords:
- documentación
- procesamiento de presentaciones
- conversión de presentaciones
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Empieza aquí: añade Aspose.Slides for Android via Java a tu aplicación, crea una primera presentación y encuentra las guías para tareas comunes, la referencia de la API y el soporte."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java es una biblioteca de clases para crear, leer, editar y convertir presentaciones PowerPoint y OpenDocument en aplicaciones Android, sin Microsoft PowerPoint.

Carga y guarda archivos PPT, PPTX, PPS, POT y ODP, incluidas variantes con macros y plantillas, y lo exporta a PDF, XPS, HTML, SVG, TIFF, Markdown e imágenes.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Comenzar</b></p>
<hr>
<p>COMENZANDO</p>
<ul>
<li><a href="/slides/es/androidjava/install-aspose-slides-for-android-via-java/">Instalación</a></li>
<li><a href="/slides/es/androidjava/create-presentation/">Crea tu primera presentación</a></li>
<li><a href="/slides/es/androidjava/getting-started/">Guía de primeros pasos</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/androidjava/supported-file-formats/">Formatos de archivo admitidos</a></li>
<li><a href="/slides/es/androidjava/evaluate-aspose-slides/">Limitaciones de la prueba</a></li>
<li><a href="/slides/es/androidjava/licensing/">Licencias</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crear con Slides</b></p>
<hr>
<p>TAREAS COMUNES</p>
<ul>
<li><a href="/slides/es/androidjava/open-presentation/">Abrir una presentación</a></li>
<li><a href="/slides/es/androidjava/save-presentation/">Guardar una presentación</a></li>
<li><a href="/slides/es/androidjava/convert-powerpoint-to-pdf/">Convertir a PDF</a></li>
<li><a href="/slides/es/androidjava/convert-slide/">Renderizar diapositivas como imágenes</a></li>
<li><a href="/slides/es/androidjava/manage-text/">Editar texto y formas</a></li>
</ul>
<p>FLUJOS DE TRABAJO DE SLIDES</p>
<ul>
<li><a href="/slides/es/androidjava/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/es/androidjava/powerpoint-animation/">Animaciones</a></li>
<li><a href="/slides/es/androidjava/manage-media-files/">Audio y vídeo</a></li>
<li><a href="/slides/es/androidjava/presentation-design/">Diseño de diapositivas</a></li>
<li><a href="/slides/es/androidjava/merge-presentation/">Combinar presentaciones</a></li>
</ul>
<p>EJEMPLOS</p>
<ul>
<li><a href="/slides/es/androidjava/examples/">Ejemplos por elemento de diapositiva</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia y Soporte</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">Referencia de API</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">Notas de la versión</a></li>
<li><a href="/slides/es/androidjava/known-issues/">Problemas conocidos</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">Descargar</a></li>
</ul>
<p>SOPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Foro de soporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Servicio de asistencia de soporte pago</a></li>
</ul>
</div>
</div>

------

## **Tu primera presentación**

La biblioteca proviene del repositorio Maven de Aspose. Los nuevos proyectos de Android Studio ya incluyen un bloque `dependencyResolutionManagement` en *settings.gradle.kts*. Añade la línea `maven` que se muestra a continuación al bloque `repositories` dentro de él, en lugar de pegar un segundo bloque:

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

Luego agrega la biblioteca a *app/build.gradle.kts* y sincroniza el proyecto:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/es/androidjava/install-aspose-slides-for-android-via-java/) cubre scripts de compilación Groovy, el archivo JAR manual y cómo elegir una versión. El código de tu primera presentación está en [Create Presentations](/slides/es/androidjava/create-presentation/): agrega un cuadro de texto a una diapositiva y guarda la presentación en el almacenamiento de tu aplicación. Ese ejemplo se ha compilado y empaquetado en un APK; no se ha ejecutado en un dispositivo. Sin una licencia, las presentaciones guardadas llevan una marca de agua de evaluación — consulta [Licensing](/slides/es/androidjava/licensing/).