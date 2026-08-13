---
title: Běžné výjimky a chyby související s fonty na Linuxu
type: docs
weight: 200
url: /cs/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Výjimka fontu, Chyba fontu, Linux, Java, Aspose.Slides pro Java"
description: "Výjimky a chyby fontů na Linuxu"
---
## **Přehled**

Když se Aspose.Slides používá na Linuxu, mohou se vyskytnout problémy související s fonty, pokud proces Java nemá přístup k požadovaným složkám fontů nebo dočasnému adresáři, pokud nejsou v systému nainstalovány žádné fonty, nebo pokud chybí požadované systémové knihovny, jako jsou fontconfig nebo libfreetype.

Tento článek popisuje běžné chyby a výjimky související s fonty na Linuxu a poskytuje řešení pro jejich odstranění. Vysvětluje, jak zkontrolovat přístup k adresářům fontů a TEMP, nainstalovat požadované fonty a knihovny a použít `FontsLoader` k načtení fontů bez jejich instalace do celého systému.

## **Chybějící text nebo obrázky (EMF nebo WMF) při spuštění kódu na Linuxu**

Tento problém nastává v systémech s omezeními v následujících případech:

1. Když nejsou nainstalovány žádné fonty nebo když není přístup k složce fontů pro proces java
2. Když není přístup k adresáři TEMP.

### **Řešení**

Zkontrolujte a potvrďte, že byl udělen přístup k adresáři TEMP i ke složce fontů. 

{{% alert color="warning" %}}
V některých případech nemusíte být schopni udělit přístup ke složkám kvůli omezením uloženým v prostředí nebo bezpečnostní politice. Vyzkoušejte tato řešení: 
{{% /alert %}}

**Obcházení**

Použijte [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader) k načtení požadovaných fontů bez jejich instalace:
```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Pokud není přístup k adresáři TEMP, použijte tento kód k určení jiného adresáře jako TEMP pro Javu:
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

## **Výjimka: InvalidOperationException: Nelze najít žádné nainstalované fonty v systému**

Tato výjimka nastane, když

1) proces Java nemá přístup ke složce fontů
2) nejsou nainstalovány žádné fonty.

### **Řešení**

1. Zkontrolujte a potvrďte, že byl udělen přístup ke složce fontů pro proces Java.

2. Nainstalujte některé fonty nebo použijte [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader).

3. Instalovat fonty.

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

   * Použitím [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **Výjimka: NoClassDefFoundError: Nepodařilo se inicializovat třídu com.aspose.slides.internal.ey.this**

Tato výjimka nastane na Linuxovém systému, který postrádá fontconfig a fonty. 

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

Navíc některé verze open-jdk (například **alpine JDK**) také **vyžadují nainstalované fonty**.

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

Tato výjimka nastane na Linuxovém systému, který postrádá knihovnu libfreetype. 

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

{{% alert title="TIP" color="info" %}} 
Nezapomeňte nainstalovat fonty nebo použít FontsLoader.
{{% /alert %}}