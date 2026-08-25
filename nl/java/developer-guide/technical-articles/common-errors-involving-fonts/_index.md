---
title: Algemene uitzonderingen en fouten met betrekking tot lettertypen op Linux
type: docs
weight: 200
url: /nl/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Lettertype‑uitzondering, Lettertype‑fout, Linux, Java, Aspose.Slides voor Java"
description: "Lettertype‑uitzonderingen en fouten op Linux"
---
## **Overzicht**

Wanneer Aspose.Slides wordt gebruikt op Linux, kunnen er lettertype‑gerelateerde problemen optreden als het Java‑proces geen toegang heeft tot de vereiste lettertype‑mappen of tijdelijke map, als er geen lettertypen op het systeem zijn geïnstalleerd, of als vereiste systeembibliotheken zoals fontconfig of libfreetype ontbreken.

Dit artikel beschrijft veelvoorkomende fouten en uitzonderingen met betrekking tot lettertypen op Linux en biedt oplossingen om ze op te lossen. Het legt uit hoe u de toegang tot de lettertype‑ en TEMP‑mappen controleert, de benodigde lettertypen en bibliotheken installeert, en `FontsLoader` gebruikt om lettertypen te laden zonder ze systeemwijd te installeren.

## **Ontbrekende tekst of afbeeldingen (EMF of WMF) wanneer code op Linux wordt uitgevoerd**

Dit probleem treedt op in systemen met beperkingen in de volgende gevallen:

1. Wanneer er geen lettertypen zijn geïnstalleerd of wanneer de lettertype‑map voor het java‑proces niet toegankelijk is
2. Wanneer de TEMP‑map niet toegankelijk is.

### **Oplossing**

Controleer en bevestig dat de toegang tot de TEMP‑map en de lettertype‑map is verleend. 

{{% alert color="warning" %}}
In sommige gevallen kunt u mogelijk geen toegang tot mappen verlenen vanwege beperkingen opgelegd door de omgeving of een beveiligingsbeleid. Probeer deze oplossingen: 
{{% /alert %}}

**Tijdelijke oplossing**

Gebruik [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader) om de benodigde lettertypen te laden zonder ze te installeren:

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

## **Uitzondering: InvalidOperationException: Kan geen enkele lettertype op het systeem vinden**

Deze uitzondering treedt op wanneer

1) het Java‑proces geen toegang heeft tot de lettertype‑map  
2) er geen lettertypen zijn geïnstalleerd.

### **Oplossing**

1. Controleer en bevestig dat de toegang tot de lettertype‑map voor het Java‑proces is verleend.

2. Installeer enige lettertypen of gebruik [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader).

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

   * Met gebruik van [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Uitzondering: InternalError: InvocationTargetException**

Bij het converteren van een PPTX-bestand naar PDF op Linux kan de conversie mislukken met `java.lang.InternalError: java.lang.reflect.InvocationTargetException`. Als de onderliggende fout aangeeft `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`, is de Linux‑lettertype‑configuratie niet beschikbaar of is de cache niet geïnitialiseerd.

### **Oplossing**

Installeer fontconfig en bouw de lettertype‑cache opnieuw op:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **Uitzondering: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

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

## **Uitzondering: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

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

{{% alert title="TIP" color="info" %}} 
Vergeet niet om lettertypen te installeren of FontsLoader te gebruiken.
{{% /alert %}}