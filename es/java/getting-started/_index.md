---
title: Primeros pasos
type: docs
weight: 10
url: /es/java/getting-started/
keywords:
- primeros pasos
- requisitos del sistema
- instalación
- primera presentación
- Maven
- procesamiento de PPT
- procesamiento de PPTX
- procesamiento de ODP
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "El camino desde un nuevo proyecto Java hasta una primera presentación guardada con Aspose.Slides: compruebe los requisitos, añada la biblioteca desde el repositorio Maven de Aspose, ejecute un primer programa y continúe con tareas comunes."
---
## **Visión general**

Siga los cuatro pasos que se describen a continuación en el orden indicado. Cada paso indica qué hacer y enlaza al artículo con los detalles. La evaluación, la licencia y el soporte se tratan después de los pasos.

## **Paso 1: Comprobar los requisitos del sistema**

Aspose.Slides for Java es un único archivo JAR sin código nativo, por lo que se ejecuta en cualquier sistema operativo que tenga un runtime de Java compatible. [Requisitos del sistema](/slides/es/java/system-requirements/) enumera los sistemas operativos y versiones de Java admitidos. El proyecto y los comandos en los pasos siguientes necesitan JDK 11 o posterior y, para la vía Maven, [Apache Maven](https://maven.apache.org/install.html).

## **Paso 2: Añadir la biblioteca a su proyecto**

Aspose.Slides for Java se publica en el propio repositorio Maven de Aspose, no en Maven Central. Elija una de estas vías:

- Con Maven: declare el repositorio `https://releases.aspose.com/java/repo/` en su *pom.xml* y añada la dependencia `com.aspose:aspose-slides` con el clasificador `jdk16`.
- Sin Maven: descargue el archivo JAR cuyo nombre termina en *-jdk16.jar* del repositorio y colóquelo en el class path.

En Linux, también instale la biblioteca fontconfig y al menos una fuente. Sin ellas, guardar una presentación falla con el error “Fontconfig head is null, check your fonts or fonts configuration”.

[Instalación](/slides/es/java/installation/) muestra las entradas *pom.xml*, la descarga del JAR y el comando para Linux.

## **Paso 3: Crear su primera presentación**

El [inicio rápido en la página principal de Aspose.Slides for Java](/slides/es/java/#your-first-presentation) es un proyecto Maven completo: un archivo *pom.xml* y un programa que añade una forma en la nube con texto a una diapositiva y guarda la presentación como un archivo PPTX. Lo ejecuta con `mvn compile exec:java`. [Crear presentaciones](/slides/es/java/create-presentation/) explica el mismo programa paso a paso. Para abrir una presentación existente y guardarla en otro formato, consulte [Abrir presentaciones](/slides/es/java/open-presentation/) y [Guardar presentaciones](/slides/es/java/save-presentation/).

## **Paso 4: Continuar con tareas comunes**

- [Abrir una presentación](/slides/es/java/open-presentation/)
- [Guardar una presentación](/slides/es/java/save-presentation/)
- [Convertir una presentación a PDF](/slides/es/java/convert-powerpoint-to-pdf/)
- [Renderizar diapositivas como imágenes](/slides/es/java/convert-slide/)
- [Editar el texto de la presentación](/slides/es/java/manage-text/)
- [Ejemplos por elemento de diapositiva](/slides/es/java/examples/)

## **Evaluar y licenciar**

Sin una licencia, Aspose.Slides se ejecuta en modo de evaluación: añade una marca de agua a cada diapositiva que guarda y trunca el texto que su código lee de las presentaciones.

- [Evaluar Aspose.Slides](/slides/es/java/evaluate-aspose-slides/) describe las limitaciones de la evaluación y cómo solicitar una licencia temporal.
- [Licenciamiento](/slides/es/java/licensing/) muestra cómo aplicar una licencia desde un archivo o un flujo.
- [Licenciamiento por uso](/slides/es/java/metered-licensing/) cubre la licencia facturada según el uso.
- [Formatos de archivo compatibles](/slides/es/java/supported-file-formats/) enumera los formatos que Aspose.Slides puede cargar y guardar.

## **Obtener ayuda**

[Soporte técnico](/slides/es/java/technical-support/) explica cómo hacer una pregunta en el [foro de soporte gratuito](https://forum.aspose.com/c/slides/es/11) y qué incluir al informar de un problema.

## **FAQ**

**¿Necesito tener instalado Microsoft PowerPoint?**

No. Aspose.Slides lee y escribe archivos de presentación por sí mismo y no utiliza PowerPoint, por lo que también se ejecuta en servidores y en Linux.

**¿Por qué Maven no encuentra Aspose.Slides for Java?**

La biblioteca no está en Maven Central. Declare el repositorio de Aspose en su *pom.xml*, como se muestra en [Instalación](/slides/es/java/installation/), y Maven descargará la biblioteca desde allí.

**¿El clasificador `jdk16` significa que la biblioteca necesita Java 16?**

No. El clasificador selecciona la compilación Java SE de la biblioteca; la otra compilación es para Android. La misma compilación se ejecuta en JDK actuales, como JDK 21.