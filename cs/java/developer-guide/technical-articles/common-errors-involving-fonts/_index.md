---
title: Běžné výjimky a chyby související s písmy na Linuxu
type: docs
weight: 200
url: /cs/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Výjimka písma, Chyba písma, Linux, Java, Aspose.Slides pro Java"
description: "Výjimky a chyby písma na Linuxu"
---
## **Přehled**

Když je Aspose.Slides používán na Linuxu, mohou nastat problémy související s písmy, pokud Java proces nemůže přistupovat k požadovaným složkám písem nebo dočasnému adresáři, pokud nejsou v systému nainstalována žádná písma, nebo pokud chybí požadované systémové knihovny, jako je fontconfig nebo libfreetype.

Tento článek popisuje běžné chyby a výjimky související s písmy na Linuxu a poskytuje řešení pro jejich odstranění. Vysvětluje, jak zkontrolovat přístup k adresářům s písmy a TEMP, nainstalovat požadovaná písma a knihovny a použít `FontsLoader` k načtení písem bez jejich instalace do celého systému.

## **Chybějící text nebo obrázky (EMF nebo WMF) při spouštění kódu na Linuxu**

Tento problém se vyskytuje v systémech s omezeními v následujících případech:

1. Když nejsou nainstalována žádná písma nebo když složka s písmy pro java proces není přístupná
2. Když není přístupný adresář TEMP.

### **Řešení**

Zkontrolujte a potvrďte, že byl udělen přístup k adresáři TEMP a složce s písmy. 

{{% alert color="warning" %}}
In některých případech můžete být neschopni udělit přístup ke složkám kvůli omezením uloženým prostředím nebo bezpečnostní politikou. Vyzkoušejte tato řešení: 
{{% /alert %}}

**Obcházející řešení**

Použijte [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader) k načtení požadovaných písem bez jejich instalace:
```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Pokud není přístupný adresář TEMP, použijte tento kód k určení jiného adresáře jako TEMP pro Javu:
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

## **Výjimka: InvalidOperationException: Nelze najít žádná písma nainstalovaná v systému**

Tato výjimka nastane, když

1) java proces nemůže přistupovat ke složce s písmy  
2) nebyla nainstalována žádná písma.

### **Řešení**

1. Zkontrolujte a potvrďte, že byl udělen přístup ke složce s písmy pro Java proces.
2. Nainstalujte některá písma nebo použijte [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader).
3. Nainstalujte písma.

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

   * Using [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Výjimka: NoClassDefFoundError: Nepodařilo se inicializovat třídu com.aspose.slides.internal.ey.this**

Tato výjimka nastane na Linux systému, který postrádá fontconfig a písma. 

### **Řešení**

Nainstalujte fontconfig:

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

Navíc některé verze open-jdk (například **alpine JDK**) také **vyžadují nainstalovaná písma**.

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

## **Výjimka: UnsatisfiedLinkError: libfreetype.so.6: Nelze otevřít sdílený soubor: Soubor nebo adresář neexistuje**

Tato výjimka nastane na Linux systému, který postrádá knihovnu libfreetype. 

### **Řešení**

Nainstalujte libfreetype a fontconfig:

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
Nezapomeňte nainstalovat písma nebo použít FontsLoader.
{{% /alert %}}