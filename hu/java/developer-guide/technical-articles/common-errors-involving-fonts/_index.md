---
title: Gyakori kivételek és hibák betűtípusokkal Linuxon
type: docs
weight: 200
url: /hu/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Betűtípus kivétel, Betűtípus hiba, Linux, Java, Aspose.Slides for Java"
description: "Betűtípus kivételek és hibák Linuxon"
---
## **Áttekintés**

Amikor az Aspose.Slides-t Linuxon használják, betűtípusokkal kapcsolatos problémák merülhetnek fel, ha a Java folyamat nem fér hozzá a szükséges betűtípus mappákhoz vagy az ideiglenes könyvtárhoz, ha nincsenek betűtípusok telepítve a rendszeren, vagy ha a szükséges rendszerkönyvtárak, például a fontconfig vagy a libfreetype hiányoznak.

Ez a cikk leírja a Linuxon előforduló betűtípusokkal kapcsolatos gyakori hibákat és kivételeket, és megoldásokat kínál a feloldásukra. Kitér arra, hogyan ellenőrizhető a betűtípus‑ és TEMP‑könyvtárak elérése, hogyan telepíthetők a szükséges betűtípusok és könyvtárak, valamint hogyan használható a `FontsLoader` a betűtípusok betöltéséhez anélkül, hogy rendszer szinten telepítenénk őket.

## **Hiányzó szöveg vagy képek (EMF vagy WMF), amikor a kód Linuxon fut**

Ez a probléma a következő korlátozásokkal rendelkező rendszereken jelentkezik:

1. Ha nincsenek betűtípusok telepítve, vagy a Java folyamat nem tudja elérni a betűtípus mappát  
2. Ha a TEMP könyvtár nem érhető el.

### **Megoldás**

Ellenőrizze és erősítse meg, hogy a TEMP könyvtárhoz és a betűtípus mappához való hozzáférés engedélyezve van.

{{% alert color="warning" %}}

Bizonyos esetekben a környezet vagy egy biztonsági szabályzat korlátozhatja a mappákhoz való hozzáférést. Próbálja meg az alábbi megkerüléseket:

{{% /alert %}}

**Megkerülés**

Használja a [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader)‑t a szükséges betűtípusok betöltéséhez a rendszer‑szintű telepítés nélkül:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Ha a TEMP könyvtár nem érhető el, használja ezt a kódot a Java TEMP könyvtárának egy másik helyre mutatásához:
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

## **Kivétel: InvalidOperationException: Nem található semmilyen betűtípus a rendszerben**

Ez a kivétel akkor fordul elő, ha

1. a Java folyamat nem fér hozzá a betűtípus mappához  
2. nincsenek betűtípusok telepítve.

### **Megoldás**

1. Ellenőrizze és erősítse meg, hogy a Java folyamat számára a betűtípus mappához való hozzáférés engedélyezve van.  

2. Telepítsen néhány betűtípust, vagy használja a [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader)-t.

3. Telepítsen betűtípusokat.

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

## **Kivétel: NoClassDefFoundError: Nem inicializálható a com.aspose.slides.internal.ey.this osztály**

Ez a kivétel egy Linux rendszerben jelentkezik, ahol hiányzik a fontconfig és a betűtípusok.

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

Ezen felül egyes open‑jdk verziók (például az **alpine JDK**) **telepített betűtípusokat** igényelnek.

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

## **Kivétel: UnsatisfiedLinkError: libfreetype.so.6: Nem nyitható meg a megosztott objektumfájl: Nincs ilyen fájl vagy könyvtár**

Ez a kivétel egy Linux rendszerben jelentkezik, ahol hiányzik a libfreetype könyvtár.

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

{{% alert title="TIPP" color="info" %}} 

Ne felejtse el telepíteni a betűtípusokat, vagy használja a FontsLoader‑t.

{{% /alert %}}