---
title: Gyakori kivételek és hibák a betűtípusokkal kapcsolatosan Linuxon
type: docs
weight: 200
url: /hu/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Betűtípus-kivétel, Betűtípus-hiba, Linux, Java, Aspose.Slides for Java"
description: "Betűtípus-kivételek és hibák Linuxon"
---
## **Áttekintés**

Ha az Aspose.Slides-et Linuxon használják, betűtípus‑problémák merülhetnek fel, ha a Java folyamat nem fér hozzá a szükséges betűtípus‑mappákhoz vagy az átmeneti könyvtárhoz, ha a rendszeren nincsenek telepített betűtípusok, vagy ha olyan szükséges rendszerkönyvtárak, mint a fontconfig vagy a libfreetype hiányoznak.

Ez a cikk bemutatja a Linuxon előforduló betűtípus‑problémákkal kapcsolatos gyakori hibákat és kivételeket, és megoldásokat kínál azok megoldásához. Ismerteti, hogyan ellenőrizhető a hozzáférés a betűtípus‑ és TEMP‑könyvtárakhoz, hogyan telepíthetők a szükséges betűtípusok és könyvtárak, valamint hogyan használható a `FontsLoader` a betűtípusok betöltéséhez a rendszer szintű telepítés nélkül.

## **Hiányzó szöveg vagy kép (EMF vagy WMF) kód Linuxon történő futtatásakor**

Ez a probléma olyan rendszerekben jelentkezik, ahol a következő esetekben korlátozások vannak:

1. Ha nincsenek telepített betűtípusok, vagy ha a Java folyamat betűtípus‑mappájához nem fér hozzá.
2. Ha a TEMP könyvtárhoz nem fér hozzá.

### **Megoldás**

Ellenőrizze és erősítse meg, hogy a TEMP könyvtárhoz és a betűtípus‑mappához való hozzáférés biztosított.

{{% alert color="warning" %}}
Bizonyos esetekben előfordulhat, hogy a környezet vagy egy biztonsági szabályzat által okozott korlátozások miatt nem tud hozzáférést adni a mappákhoz. Próbálja ki a következő megoldásokat:
{{% /alert %}}

**Megoldás**

Használja a [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader) osztályt a szükséges betűtípusok betöltéséhez a telepítés nélkül:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Ha a TEMP könyvtárhoz nem fér hozzá, használja ezt a kódot egy másik könyvtár megadásához Java TEMP‑ként:

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

## **Kivétel: InvalidOperationException: Nem található telepített betűtípus a rendszerben**

Ez a kivétel a következő esetekben fordul elő:

1. a Java folyamat nem fér hozzá a betűtípus‑mappához  
2. nincs telepített betűtípus.

### **Megoldás**

1. Ellenőrizze és erősítse meg, hogy a Java folyamat betűtípus‑mappájához való hozzáférés biztosított.
2. Telepítsen néhány betűtípust, vagy használja a [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader) osztályt.
3. Betűtípusok telepítése.

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

   * A [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader) használatával: 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Kivétel: InternalError: InvocationTargetException**

Linuxon PPTX fájl PDF‑re konvertálásakor a konvertálás `java.lang.InternalError: java.lang.reflect.InvocationTargetException` hibával meghiúsulhat. Ha az alapvető hiba azt jelzi, hogy `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`, akkor a Linux betűtípus‑konfiguráció nem érhető el, vagy a gyorsítótár még nincs inicializálva.

### **Megoldás**

Telepítse a fontconfig‑ot és építse újra a betűtípus‑gyorsítótárat:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **Kivétel: NoClassDefFoundError: Nem sikerült inicializálni a com.aspose.slides.internal.ey.this osztályt**

Ez a kivétel egy olyan Linux rendszeren jelentkezik, ahol hiányzik a fontconfig és a betűtípusok.

### **Megoldás**

Telepítse a fontconfig‑ot:

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

Továbbá egyes open‑jdk verziók (például a **alpine JDK**) szintén **telepített betűtípusokat igényelnek**.

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

## **Kivétel: UnsatisfiedLinkError: libfreetype.so.6: Nem nyitható meg a megosztott objektum fájl: Nincs ilyen fájl vagy könyvtár**

Ez a kivétel egy olyan Linux rendszeren jelentkezik, ahol a libfreetype könyvtár hiányzik.

### **Megoldás**

Telepítse a libfreetype‑t és a fontconfig‑ot:

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
Ne felejtse el telepíteni a betűtípusokat, vagy használja a FontsLoader‑t.
{{% /alert %}}