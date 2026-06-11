---
title: Vanliga undantag och fel relaterade till typsnitt på Linux
type: docs
weight: 200
url: /sv/java/common-errors-involving-fonts/
keywords: "Typsnittsunantag, Typsnittsfel, Linux, Java, Aspose.Slides för Java"
description: "Typsnittsunantag och fel på Linux"
---
## **Översikt**

När Aspose.Slides används på Linux kan problem relaterade till typsnitt uppstå om Java‑processen inte kan komma åt de nödvändiga typsnittsmapparna eller den temporära katalogen, om inga typsnitt är installerade på systemet, eller om nödvändiga systembibliotek såsom fontconfig eller libfreetype saknas.

Denna artikel beskriver vanliga fel och undantag relaterade till typsnitt på Linux och ger lösningar för att åtgärda dem. Den förklarar hur man kontrollerar åtkomst till typsnitt‑ och TEMP‑katalogerna, installerar de erforderliga typsnitten och biblioteken, samt använder `FontsLoader` för att läsa in typsnitt utan att installera dem systemomfattande.

## **Saknad text eller bilder (EMF eller WMF) när kod körs på Linux**

Detta problem uppstår i system med begränsningar i följande fall:

1. När inga typsnitt är installerade eller när typsnittsmappen för java‑processen inte kan nås
2. När TEMP‑katalogen inte kan nås.

### **Lösning**

Kontrollera och bekräfta att åtkomst till TEMP‑katalogen och typsnittsmappen har beviljats. 

{{% alert color="warning" %}}
I vissa fall kan du vara oförmögen att bevilja åtkomst till mappar på grund av begränsningar som miljön eller en säkerhetspolicy pålägger. Prova följande lösningar: 
{{% /alert %}}

**Alternativ lösning**

Använd [FontsLoader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsLoader) för att läsa in de nödvändiga typsnitten utan att installera dem:

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

## **Undantag: InvalidOperationException: Kan inte hitta några typsnitt installerade på systemet**

Detta undantag uppstår när

1) Java‑processen inte kan komma åt typsnittsmappen  
2) inga typsnitt har installerats.

### **Lösning**

1. Kontrollera och bekräfta att åtkomst till typsnittsmappen för Java‑processen har beviljats.

2. Installera några typsnitt eller använd [FontsLoader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsLoader).

3. Installera typsnitt.

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

   * Använda [FontsLoader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Undantag: NoClassDefFoundError: Kunde inte initiera klassen com.aspose.slides.internal.ey.this**

Detta undantag uppstår på ett Linux‑system som saknar fontconfig och typsnitt. 

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

Dessutom kräver vissa open‑jdk‑versioner (t.ex. **alpine JDK**) också **installerade typsnitt**.

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

## **Undantag: UnsatisfiedLinkError: libfreetype.so.6: Kan inte öppna delad objektfil: Filen finns inte**

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

{{% alert title="TIP" color="primary" %}} 
Glöm inte att installera typsnitt eller använda FontsLoader. 
{{% /alert %}}