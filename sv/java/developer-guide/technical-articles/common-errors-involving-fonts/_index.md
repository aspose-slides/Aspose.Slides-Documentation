---
title: Vanliga undantag och fel relaterade till teckensnitt på Linux
type: docs
weight: 200
url: /sv/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Teckensnitt undantag, Teckensnitt fel, Linux, Java, Aspose.Slides för Java"
description: "Teckensnitt undantag och fel på Linux"
---
## **Översikt**

När Aspose.Slides används på Linux kan problem relaterade till teckensnitt uppstå om Java‑processen inte kan komma åt de nödvändiga teckensnittsmapparna eller den temporära katalogen, om inga teckensnitt är installerade på systemet, eller om nödvändiga systembibliotek såsom fontconfig eller libfreetype saknas.

Denna artikel beskriver vanliga fel och undantag relaterade till teckensnitt på Linux och ger lösningar för att åtgärda dem. Den förklarar hur man kontrollerar åtkomst till teckensnitts‑ och TEMP‑kataloger, installerar de nödvändiga teckensnitten och biblioteken samt använder `FontsLoader` för att ladda teckensnitt utan att installera dem systemomfattande.

## **Saknad text eller bilder (EMF eller WMF) när kod körs på Linux**

Detta problem uppstår i system med begränsningar i följande fall:

1. När inga teckensnitt är installerade eller när teckensnittsmappen för Java‑processen inte kan nås
2. När TEMP‑katalogen inte kan nås.

### **Lösning**

Kontrollera och bekräfta att åtkomst till TEMP‑katalogen och teckensnittsmappen har beviljats. 

{{% alert color="warning" %}}
I vissa fall kan du vara oförmögen att bevilja åtkomst till mappar på grund av begränsningar som införts av miljön eller en säkerhetspolicy. Prova dessa lösningar: 
{{% /alert %}}

**Tillfällig lösning**

Använd [FontsLoader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsLoader) för att ladda de nödvändiga teckensnitten utan att installera dem:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Om TEMP‑katalogen inte kan nås, använd denna kod för att ange en annan katalog som TEMP för Java:
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

## **Undantag: InvalidOperationException: Kan inte hitta några teckensnitt installerade på systemet**

Detta undantag uppstår när

1) Java‑processen inte kan komma åt teckensnittsmappen  
2) inga teckensnitt har installerats.

### **Lösning**

1. Kontrollera och bekräfta att åtkomst till teckensnittsmappen för Java‑processen har beviljats.  
2. Installera några teckensnitt eller använd [FontsLoader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsLoader).  
3. Installera teckensnitt.

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

   * Med hjälp av [FontsLoader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **Undantag: InternalError: InvocationTargetException**

När en PPTX‑fil konverteras till PDF på Linux kan konverteringen misslyckas med `java.lang.InternalError: java.lang.reflect.InvocationTargetException`. Om det underliggande felet visar `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`, är Linux‑teckensnittskonfigurationen otillgänglig eller har inte initierat sin cache.

### **Lösning**

Installera fontconfig och bygg om teckensnittscachen:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **Undantag: NoClassDefFoundError: Kunde inte initiera klass com.aspose.slides.internal.ey.this**

Detta undantag uppstår på ett Linux‑system som saknar fontconfig och teckensnitt. 

### **Lösning**

Installera fontconfig:

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

Dessutom kräver vissa versioner av open‑jdk (t.ex. **alpine JDK**) också **installerade teckensnitt**.

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

## **Undantag: UnsatisfiedLinkError: libfreetype.so.6: Kan inte öppna delad objektfil: Ingen sådan fil eller katalog**

Detta undantag uppstår på ett Linux‑system som saknar libfreetype‑biblioteket. 

### **Lösning**

Installera libfreetype och fontconfig:

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
Glöm inte att installera teckensnitt eller använda FontsLoader.
{{% /alert %}}