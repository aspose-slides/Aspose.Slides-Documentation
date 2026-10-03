---
title: Seguridad
type: docs
weight: 160
url: /es/java/security/
keywords:
- seguridad
- dependencias
- componentes de terceros
- Maven
- firma JAR
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revisa cómo Aspose.Slides for Java procesa presentaciones, qué añade a las dependencias de tu proyecto, cómo verificar el archivo JAR y qué componentes de terceros incluye."
---
## **Introducción**

Este artículo reúne la información que normalmente necesita una revisión de seguridad de una aplicación que usa Aspose.Slides for Java: cómo la biblioteca procesa presentaciones, qué añade a las dependencias de tu proyecto, cómo comprobar que el archivo JAR proviene de Aspose y qué componentes de terceros contiene el archivo JAR.

## **Seguridad en Aspose.Slides**

Aspose aplica las mejores prácticas al desarrollar sus productos.

* Aspose.Slides for Java se utiliza para crear, modificar y convertir presentaciones. No ejecuta scripts en las presentaciones. Aspose.Slides analiza la estructura de la presentación y permite que tu código trabaje con el modelo de objetos.
* Aspose.Slides funciona como una biblioteca que analiza e interpreta documentos sin ejecutar código remoto. Todos los productos Aspose se ejecutan en tus máquinas. No transmiten datos a Aspose. La única excepción es [metered licensing](/slides/es/java/metered-licensing/): si lo utilizas, solo se procesa la información de uso de la API.
* Los componentes Aspose se ejecutan en el mismo contexto de usuario que las aplicaciones normales. Por lo tanto, los componentes Aspose no suponen un riesgo para los recursos críticos del sistema. Además, cuando un componente Aspose abre un documento, las macros no se ejecutan automáticamente.

## **Dependencias de Maven**

El artefacto Maven de Aspose.Slides for Java, `com.aspose:aspose-slides`, no declara dependencias: su archivo POM contiene solo las coordenadas del propio artefacto. Cuando lo añades a un proyecto, Maven agrega este único archivo JAR y nada más. Para enumerar cada artefacto que resuelve tu proyecto, incluidas las dependencias transitivas, ejecuta este comando en la carpeta del proyecto:

```bash
mvn dependency:tree
```

En el proyecto de la [Instalación](/slides/es/java/installation/), la salida muestra Aspose.Slides como la única dependencia:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Verificar el archivo JAR**

Aspose firma el archivo JAR. Para comprobar la firma, ejecuta la herramienta `jarsigner` del JDK en la carpeta que contiene el archivo JAR:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

El comando muestra `jar verified.` cuando la firma es válida y ninguna entrada ha cambiado desde que se firmó el archivo. Este mensaje no indica el firmante. Para confirmar que Aspose firmó el archivo, añade las opciones `-verbose` y `-certs` y verifica que el certificado del firmante está emitido a `CN=ASPOSE PTY LTD`. Cuando Maven descarga el archivo JAR, también comprueba la suma de verificación SHA‑1 que el repositorio publica junto al archivo.

## **Componentes de terceros**

Aspose.Slides for Java incluye código y datos de componentes de terceros. Forman parte del archivo JAR, no de artefactos Maven separados, por lo que `mvn dependency:tree` y otras herramientas que leen dependencias Maven no los listan. El archivo JAR contiene el aviso *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, que enumera los componentes y sus licencias:

| Componente | Licencia indicada en el aviso |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Para extraer el aviso del archivo JAR, ejecuta la herramienta `jar` del JDK en la carpeta que contiene el archivo JAR:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **Preguntas frecuentes**

**¿Aspose.Slides for Java utiliza paquetes externos?**

No tiene dependencias Maven, como muestra [Dependencias de Maven](#maven-dependencies), pero incluye los componentes de terceros enumerados en [Componentes de terceros](#third-party-components). Incluye tanto el archivo JAR como estos componentes en tu revisión de seguridad.

**¿Aspose.Slides for Java necesita acceso a la red?**

No. Crear, guardar y renderizar presentaciones funciona en un sistema sin conexión a red. La única función que envía datos a Aspose es [metered licensing](/slides/es/java/metered-licensing/), que informa del uso de la API.

**¿Aspose.Slides for Java contiene código nativo?**

No. El archivo JAR contiene solo clases y recursos Java, por lo que no añade bibliotecas nativas a tu aplicación. En Linux, el soporte de fuentes del runtime Java necesita la biblioteca fontconfig y fuentes del sistema operativo; consulta [Requisitos del sistema](/slides/es/java/system-requirements/#linux).