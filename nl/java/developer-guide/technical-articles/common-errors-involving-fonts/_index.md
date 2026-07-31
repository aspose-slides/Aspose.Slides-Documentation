---
title: "Algemene uitzonderingen en fouten met betrekking tot lettertypen op Linux"
type: docs
weight: 200
url: /nl/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Lettertype‑uitzondering, Lettertype‑fout, Linux, Java, Aspose.Slides voor Java"
description: "Lettertype‑uitzonderingen en -fouten op Linux"
---
## **Overzicht**

Wanneer Aspose.Slides op Linux wordt gebruikt, kunnen er fontgerelateerde problemen optreden als het Java-proces geen toegang heeft tot de vereiste fontmappen of tijdelijke map, als er geen lettertypen op het systeem zijn geïnstalleerd, of als vereiste systeembibliotheken zoals fontconfig of libfreetype ontbreken.

Dit artikel beschrijft veelvoorkomende fouten en uitzonderingen met betrekking tot lettertypen op Linux en biedt oplossingen om ze op te lossen. Het legt uit hoe u de toegang tot de font‑ en TEMP‑mappen kunt controleren, de benodigde lettertypen en bibliotheken kunt installeren, en hoe u `FontsLoader` gebruikt om lettertypen te laden zonder ze systeembreed te installeren.

## **Ontbrekende tekst of afbeeldingen (EMF of WMF) wanneer code wordt uitgevoerd op Linux**

Dit probleem treedt op in systemen met beperkingen in de volgende gevallen:

1. Wanneer er geen lettertypen zijn geïnstalleerd of wanneer de fontmap voor het Java‑proces niet toegankelijk is
2. Wanneer de TEMP‑map niet toegankelijk is.

### **Oplossing**

Controleer en bevestig dat toegang tot de TEMP‑map en de fontmap is verleend. 

{{% alert color="warning" %}}

In sommige gevallen kunt u mogelijk geen toegang tot mappen verlenen vanwege beperkingen opgelegd door de omgeving of een beveiligingsbeleid. Probeer de volgende oplossingen: 

{{% /alert %}}

**Oplossing**

Gebruik [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader) om de vereiste lettertypen te laden zonder ze te installeren:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Als de TEMP‑map niet toegankelijk is, gebruik dan deze code om een andere map als TEMP voor Java op te geven:
``` 
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **Uitzondering: InvalidOperationException: Kan geen geïnstalleerde lettertypen op het systeem vinden**

Deze uitzondering treedt op wanneer

1) het Java‑proces geen toegang heeft tot de fontmap
2) er geen lettertypen zijn geïnstalleerd.

### **Oplossing**

1. Controleer en bevestig dat toegang tot de fontmap voor het Java‑proces is verleend.

2. Installeer enkele lettertypen of gebruik [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader).

3. Installeer lettertypen.

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```

   * Met behulp van [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **Uitzondering: NoClassDefFoundError: Kan klasse com.aspose.slides.internal.ey.this niet initialiseren**

Deze uitzondering treedt op op een Linux‑systeem dat geen fontconfig en geen lettertypen heeft. 

### **Oplossing**

Installeer fontconfig:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
```

Daarnaast vereisen sommige open‑jdk‑versies (bijvoorbeeld **alpine JDK**) ook **geïnstalleerde lettertypen**.

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **Uitzondering: UnsatisfiedLinkError: libfreetype.so.6: Kan gedeeld objectbestand niet openen: Bestand of map bestaat niet**

Deze uitzondering treedt op op een Linux‑systeem dat de libfreetype‑bibliotheek mist. 

### **Oplossing**

Installeer libfreetype en fontconfig:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="primary" %}} 
Vergeet niet om lettertypen te installeren of FontsLoader te gebruiken.
{{% /alert %}}