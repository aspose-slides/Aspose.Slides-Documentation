---
title: Instalación
type: docs
weight: 70
url: /es/java/installation/
---

{{% alert color="primary" %}} 

Aspose.Slides para Java no requiere Microsoft PowerPoint. Genera los archivos de presentación necesarios programáticamente. Sin embargo, para ver una presentación generada, puede que tengas que utilizar un visor de PowerPoint o de presentaciones. 

{{% /alert %}} 

## **Instalación y Configuración de Java**
Java es un lenguaje de programación popular que te permite ejecutar programas en muchas plataformas. 

Para obtener información sobre cómo instalar y configurar Java en cualquier sistema operativo, visita https://java.com/.

## **Instalando Aspose.Slides para Java desde el Repositorio de Maven**
Aspose aloja todas las APIs de Java en [repositorios de Maven](https://releases.aspose.com/java/repo/com/aspose/). Puedes usar la API [Aspose.Slides para Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) directamente en tus proyectos de Maven con configuraciones simples.

1. **Especificar la Configuración del Repositorio de Maven**

   Especifica la configuración/ubicación del Repositorio de Maven de Aspose en tu pom.xml de Maven de la siguiente manera:

``` xml
<repositories>
    <repository>
        <id>AsposeJavaAPI</id>
        <name>API de Aspose Java</name>
        <url>https://releases.aspose.com/java/repo/</url>
    </repository>
</repositories>
```
2. **Definir la Dependencia de la API Aspose.Slides para Java**

   Define la dependencia de la API Aspose.Slides para Java en tu pom.xml de la siguiente manera:

``` xml
<dependencies>
    <dependency>
        <groupId>com.aspose</groupId>
        <artifactId>aspose-slides</artifactId>
        <version>XX.XX</version>
        <classifier>jdk16</classifier>
    </dependency>
    <dependency>
        <groupId>com.aspose</groupId>
        <artifactId>aspose-slides</artifactId>
        <version>XX.XX</version>
        <classifier>javadoc</classifier>
    </dependency>
</dependencies>
```

La dependencia de Aspose.Slides para Java se definirá entonces en tu proyecto de Maven.