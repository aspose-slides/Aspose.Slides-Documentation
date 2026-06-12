---
title: Běžné výjimky a chyby související s fonty na Linuxu
type: docs
weight: 200
url: /cs/java/common-errors-involving-fonts/
keywords: "Výjimka fontu, Chyba fontu, Linux, Java, Aspose.Slides pro Java"
description: "Výjimky a chyby fontů na Linuxu"
---
## **Přehled**

Když je Aspose.Slides používán na Linuxu, mohou se vyskytnout problémy související s fonty, pokud Java proces nemůže získat přístup k požadovaným složkám s fonty nebo dočasnému adresáři, pokud nejsou ve systému nainstalovány žádné fonty, nebo pokud chybí požadované systémové knihovny, jako je fontconfig nebo libfreetype.

## **Chybějící text nebo obrázky (EMF nebo WMF) při spouštění kódu na Linuxu**

Tento problém se vyskytuje v systémech s omezeními v těchto případech:

1. Když nejsou nainstalovány žádné fonty nebo když není přístupná složka s fonty pro Java proces
2. Když není přístupný adresář TEMP.

### **Řešení**

Zkontrolujte a potvrďte, že přístup k adresáři TEMP a složce s fonty byl povolen. 

{{% alert color="warning" %}}
V některých případech může být přidělení přístupu ke složkám omezeno prostředím nebo bezpečnostní politikou. Vyzkoušejte následující řešení: 
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

Tato výjimka nastává, když

1) Java proces nemůže získat přístup ke složce s fonty  
2) nebyly nainstalovány žádné fonty.

### **Řešení**

1. Zkontrolujte a potvrďte, že přístup ke složce s fonty pro Java proces byl povolen.

2. Nainstalujte nějaké fonty nebo použijte [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader).

3. Instalace fontů.

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

   * Použití [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Výjimka: NoClassDefFoundError: Nepodařilo se inicializovat třídu com.aspose.slides.internal.ey.this**

Tato výjimka nastává na Linux systému, který postrádá fontconfig a fonty. 

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

## **Výjimka: UnsatisfiedLinkError: libfreetype.so.6: Nelze otevřít sdílený objekt: Soubor nebo adresář neexistuje**

Tato výjimka nastává na Linux systému, který postrádá knihovnu libfreetype. 

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
Nezapomeňte nainstalovat fonty nebo použít FontsLoader.
{{% /alert %}}