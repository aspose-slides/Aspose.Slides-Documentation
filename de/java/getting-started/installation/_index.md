---
title: Installation
type: docs
weight: 70
url: /java/installation/
---

{{% alert color="primary" %}} 

Aspose.Slides für Java erfordert Microsoft PowerPoint nicht. Es generiert die benötigten Präsentationsdateien programmgesteuert. Um eine generierte Präsentation anzuzeigen, müssen Sie jedoch möglicherweise einen PowerPoint- oder Präsentationsbetrachter verwenden. 

{{% /alert %}} 

## **Installation und Konfiguration von Java**
Java ist eine beliebte Programmiersprache, mit der Sie Programme auf vielen Plattformen ausführen können. 

Für Informationen zur Installation und Konfiguration von Java auf einem Betriebssystem besuchen Sie https://java.com/.

## **Installation von Aspose.Slides für Java aus dem Maven-Repository**
Aspose hostet alle Java-APIs in den [Maven-Repositories](https://releases.aspose.com/java/repo/com/aspose/). Sie können die [Aspose.Slides für Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) API direkt in Ihren Maven-Projekten mit einfachen Konfigurationen verwenden.

1. **Geben Sie die Maven-Repository-Konfiguration an**

   Geben Sie die Aspose Maven Repository-Konfiguration/-Standort in Ihrer Maven pom.xml wie folgt an:

``` xml
<repositories>
    <repository>
        <id>AsposeJavaAPI</id>
        <name>Aspose Java API</name>
        <url>https://releases.aspose.com/java/repo/</url>
    </repository>
</repositories>
```
2. **Definieren Sie die Abhängigkeit von Aspose.Slides für Java API**

   Definieren Sie die Abhängigkeit von Aspose.Slides für Java API in Ihrer pom.xml wie folgt:

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

Die Abhängigkeit von Aspose.Slides für Java wird dann in Ihrem Maven-Projekt definiert.