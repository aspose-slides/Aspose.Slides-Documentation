---
title: Gyakori kivételek és hibák betűtípusokkal Linuxon
type: docs
weight: 200
url: /hu/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Betűtípus-kivétel, Betűtípus-hiba, Linux, Java, Aspose.Slides for Java"
description: "Betűtípus-kivétel és hibák Linuxon"
---
## **Áttekintés**

Amikor az Aspose.Slides‑t Linuxon használják, betűtípussal kapcsolatos problémák merülhetnek fel, ha a Java folyamat nem fér hozzá a szükséges betűtípus‑mappákhoz vagy az ideiglenes könyvtárhoz, ha a rendszeren nincsenek telepített betűtípusok, vagy ha a szükséges rendszerkönyvtárak, például a fontconfig vagy a libfreetype hiányoznak.

Ez a cikk leírja a Linuxon előforduló betűtípusokkal kapcsolatos gyakori hibákat és kivételeket, és megoldásokat kínál azok elhárításához. Bemutatja, hogyan ellenőrizhető a betűtípus‑ és TEMP‑könyvtárak elérhetősége, a szükséges betűtípusok és könyvtárak telepítése, valamint a `FontsLoader` használata a betűtípusok rendszerre telepítés nélküli betöltéséhez.

## **Hiányzó szöveg vagy képek (EMF vagy WMF) kódfuttatáskor Linuxon**

Ez a probléma a következő esetekben korlátozásokkal rendelkező rendszereknél jelentkezik:

1. Ha nincsenek telepített betűtípusok, vagy ha a Java folyamat számára a betűtípus‑mappa nem érhető el
2. Ha az TEMP könyvtár nem érhető el.

### **Megoldás**

Ellenőrizze és erősítse meg, hogy a TEMP könyvtárhoz és a betűtípusok mappájához való hozzáférés engedélyezve van. 

{{% alert color="warning" %}}
Egyes esetekben a környezet vagy egy biztonsági házirend által szabott korlátozások miatt nem biztos, hogy engedélyezni tudja a mappákhoz való hozzáférést. Próbálja ki az alábbi megoldásokat: 
{{% /alert %}}

**Kikerülő megoldás**

Használja a [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader) eszközt a szükséges betűtípusok telepítés nélküli betöltéséhez:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Ha a TEMP könyvtár nem érhető el, használja ezt a kódot a Java számára egy másik TEMP könyvtár megadásához:
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

## **Kivétel: InvalidOperationException: Nem található a rendszerben telepített betűtípus**

Ez a kivétel a következők esetén fordul elő:

1) a Java folyamat nem fér hozzá a betűtípus‑mappához  
2) nincsenek telepített betűtípusok.

### **Megoldás**

1. Ellenőrizze és erősítse meg, hogy a Java folyamat számára a betűtípus‑mappához való hozzáférés engedélyezve van.

2. Telepítsen néhány betűtípust, vagy használja a [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader) eszközt.

3. Telepítse a betűtípusokat.

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

   * A [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader) használata: 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Kivétel: NoClassDefFoundError: Nem inicializálható a com.aspose.slides.internal.ey.this osztály**

Ez a kivétel egy Linux rendszerben fordul elő, amelyen hiányzik a fontconfig és a betűtípusok. 

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

Ezen felül bizonyos open‑jdk verziók (például **alpine JDK**) szintén **telepített betűtípusokat igényelnek**.

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

## **Kivétel: UnsatisfiedLinkError: libfreetype.so.6: Nem nyitható meg a megosztott objektum fájl: Nem található ilyen fájl vagy könyvtár**

Ez a kivétel egy Linux rendszerben fordul elő, amelyen hiányzik a libfreetype könyvtár. 

### **Megoldás**

Telepítse a libfreetype‑ot és a fontconfig‑ot:

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
Ne felejtse el telepíteni a betűtípusokat vagy használni a FontsLoader‑t.
{{% /alert %}}  