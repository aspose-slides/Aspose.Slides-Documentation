---
title: Veelvoorkomende uitzonderingen en fouten met lettertypen op Linux
type: docs
weight: 200
url: /nl/java/common-errors-involving-fonts/
keywords: "Lettertype-uitzondering, Lettertype-fout, Linux, Java, Aspose.Slides voor Java"
description: "Lettertype-uitzonderingen en -fouten op Linux"
---
## **Overzicht**

Wanneer Aspose.Slides op Linux wordt gebruikt, kunnen er lettertype‑gerelateerde problemen optreden als het Java‑proces geen toegang heeft tot de benodigde lettertype‑mappen of de tijdelijke map, als er geen lettertypen op het systeem geïnstalleerd zijn, of als vereiste systeembibliotheken zoals fontconfig of libfreetype ontbreken.

Dit artikel beschrijft veelvoorkomende fouten en uitzonderingen met betrekking tot lettertypen op Linux en biedt oplossingen om deze op te lossen. Het legt uit hoe je de toegang tot lettertype‑ en TEMP‑mappen controleert, de benodigde lettertypen en bibliotheken installeert, en `FontsLoader` gebruikt om lettertypen te laden zonder ze systeemwijd te installeren.

## **Ontbrekende tekst of afbeeldingen (EMF of WMF) wanneer code wordt uitgevoerd op Linux**

Dit probleem treedt op in systemen met beperkingen in de volgende gevallen:

1. Wanneer er geen lettertypen geïnstalleerd zijn of wanneer de lettertype‑map voor het Java‑proces niet toegankelijk is
2. Wanneer de TEMP‑map niet toegankelijk is.

### **Oplossing**

Controleer en bevestig dat toegang tot de TEMP‑map en de lettertype‑map is verleend. 

{{% alert color="warning" %}}
In sommige gevallen kun je mogelijk geen toegang verlenen tot mappen vanwege beperkingen opgelegd door de omgeving of een beveiligingsbeleid. Probeer de volgende oplossingen: 
{{% /alert %}}

**Omzeilingsmethode**

Gebruik [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader) om de vereiste lettertypen te laden zonder ze systeemwijd te installeren:

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

## **Uitzondering: InvalidOperationException: Kan geen enkele geïnstalleerde lettertype op het systeem vinden**

Deze uitzondering treedt op wanneer

1) het Java‑proces geen toegang heeft tot de lettertype‑map  
2) er geen lettertypen geïnstalleerd zijn.

### **Oplossing**

1. Controleer en bevestig dat toegang tot de lettertype‑map voor het Java‑proces is verleend.  

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

   * Using [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/FontsLoader):  

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Uitzondering: NoClassDefFoundError: Kon klasse com.aspose.slides.internal.ey.this niet initialiseren**

Deze uitzondering treedt op op een Linux‑systeem dat fontconfig en lettertypen mist. 

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

Bovendien vereisen sommige open-jdk‑versies (bijvoorbeeld **alpine JDK**) ook **geïnstalleerde lettertypen**.

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

## **Uitzondering: UnsatisfiedLinkError: libfreetype.so.6: Kan gedeeld objectbestand niet openen: Bestand bestaat niet**

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