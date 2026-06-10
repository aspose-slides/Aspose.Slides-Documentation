---
title: Betűtípusokkal kapcsolatos gyakori kivételek és hibák Linuxon
type: docs
weight: 200
url: /hu/java/common-errors-involving-fonts/
keywords: "Betűtípus kivétel, Betűtípus hiba, Linux, Java, Aspose.Slides for Java"
description: "Betűtípus kivételek és hibák Linuxon"
---
## **Áttekintés**

Amikor az Aspose.Slides‑t Linux alatt használják, betűtípusokkal kapcsolatos problémák merülhetnek fel, ha a Java folyamat nem fér hozzá a szükséges betűtípus mappákhoz vagy az ideiglenes könyvtárhoz, ha a rendszeren nincsenek telepítve betűtípusok, vagy ha a szükséges rendszerkönyvtárak, például a fontconfig vagy a libfreetype hiányoznak.

Ez a cikk a Linuxon előforduló betűtípusokkal kapcsolatos gyakori hibákat és kivételeket írja le, és megoldásokat nyújt azok megoldására. Bemutatja, hogyan ellenőrizhető a betűtípusok és a TEMP könyvtárak hozzáférése, hogyan telepíthetők a szükséges betűtípusok és könyvtárak, valamint hogyan használható a `FontsLoader` a betűtípusok betöltésére anélkül, hogy azokat rendszer szinten telepítenénk.

## **Hiányzó szöveg vagy képek (EMF vagy WMF) amikor a kód Linuxon hajtódik végre**

Ez a probléma olyan rendszereknél jelentkezik, ahol korlátozások vannak az alábbi esetekben:

1. Ha nincsenek telepítve betűtípusok, vagy ha a Java folyamat számára a betűtípus mappa nem érhető el
2. Ha az TEMP könyvtár nem érhető el.

### **Megoldás**

Ellenőrizze és erősítse meg, hogy a TEMP könyvtárhoz és a betűtípusok mappájához való hozzáférés engedélyezve van. 

{{% alert color="warning" %}}

Bizonyos esetekben előfordulhat, hogy a környezet vagy egy biztonsági szabályzat által előírt korlátozások miatt nem tudja engedélyezni a mappákhoz való hozzáférést. Próbálja ki ezeket a megoldásokat: 

{{% /alert %}}

**Megkerülés**

Használja a [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader) funkciót a szükséges betűtípusok betöltéséhez anélkül, hogy telepítené őket:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Ha a TEMP könyvtár nem érhető el, használja ezt a kódot egy másik könyvtár megadásához TEMP‑ként a Java számára:
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

Ez a kivétel a következő esetekben fordul elő

1) a Java folyamat nem fér hozzá a betűtípus mappához  
2) nincs telepítve betűtípus.

### **Megoldás**

1. Ellenőrizze és erősítse meg, hogy a Java folyamat számára a betűtípus mappához való hozzáférés engedélyezve van.

2. Telepítsen néhány betűtípust, vagy használja a [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader) funkciót.

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

   * [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsLoader) használatával: 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **Kivétel: NoClassDefFoundError: Nem sikerült inicializálni a com.aspose.slides.internal.ey.this osztályt**

Ez a kivétel egy olyan Linux rendszeren fordul elő, ahol hiányzik a fontconfig és a betűtípusok. 

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

Ezen kívül egyes open‑jdk verziók (például a **alpine JDK**) szintén **telepített betűtípusokat igényelnek**.

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

## **Kivétel: UnsatisfiedLinkError: libfreetype.so.6: Nem nyitható meg a megosztott objektum fájl: Nem létezik ilyen fájl vagy könyvtár**

Ez a kivétel egy olyan Linux rendszeren fordul elő, ahol hiányzik a libfreetype könyvtár. 

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
Ne felejtse el telepíteni a betűtípusokat vagy használja a FontsLoader‑t.
{{% /alert %}}