---
title: Deklaráció
type: docs
weight: 60
url: /hu/java/artifact-classifier-change/
keywords:
- Aspose.Slides osztályozó
- artifact osztályozó
- Aspose.Slides használata
- Aspose.Slides telepítése
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java most a jdk8 osztályozót használja a jdk16 helyett. Ismerje meg, miért és hogyan frissítheti a függőségeit."
---
## **Artifact osztályozó változtatás `jdk16`‑ról `jdk8`‑ra**

A **26.10**‑es verziótól kezdve a közzétett csomagok osztályozóját **`jdk16`**‑ról (**Java 6**) **`jdk8`**‑ra (**Java 8**) módosítottuk.

### **Mi változott**

| | Előtte | Utána |
|---|---|---|
| Osztályozó | `jdk16` | `jdk8` |
| Minimális Java verzió | Java 1.6 | Java 8 |

**Előtte:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Utána:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Miért hajtottuk végre ezt a változtatást**

Belső felülvizsgálat után úgy döntöttünk, hogy **lemondjuk a régebbi Java verziók támogatását**, amelyek már nem hoznak értéket, sőt a karbantartást is akadályozzák. A Java 8-at választottuk új, biztonságos alapvonalnak minden felhasználó számára.

Ennek részeként frissítettük az osztályozót, hogy tükrözze a ténylegesen támogatott minimális verziót. Emellett igazodtunk a jelenlegi Oracle elnevezési konvencióhoz, ahol a terméket hivatalosan **JDK 8**‑ként (nem a régi `1.8` formátumban) hívják.

### **Mit kell tennie**

1. **Frissítse az osztályozót** a függőségi deklarációiban `jdk16`‑ról `jdk8`‑ra.

   **Maven:**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **Ellenőrizze**, hogy a futtatókörnyezete Java 8 vagy újabb.

3. **Frissítse** a zárolási fájlokat vagy a függőségi cache‑eket, amelyek az eredeti osztályozót rögzítik.

### **Migrációs megjegyzés: jdk16 és jdk8**

A 26.10‑es verziótól kezdve mind a jdk16, mind a jdk8 osztályozó Java 8‑kompatibilis JAR‑okat biztosít (a forrás‑/cél‑kompatibilitás Java 8‑ra van beállítva).

 - `jdk16` → **folytatja** a közzétételt a visszafelé kompatibilitás érdekében (létező integrációk).
 - `jdk8` → **új, előnyben részesített** osztályozó Java 8 környezetekhez.

⚠️ **Megjegyzés:** Ez a kettős kiadási fázis 2027. martius 31‑ig tart. Ezt követően a jdk16 osztályozót megszüntetik, és csak a jdk8 lesz támogatott.

### **Kompatibilitási megjegyzések**

- A `jdk16` osztályozó **már nem lesz közzétéve** **2027. martius 31.** után.
- Ha továbbra is Java 1.6 támogatásra van szüksége, maradjon a korábbi főverzió sorozatán, amíg át nem tud migrálni.

### **Szüksége van segítségre?**

Ha a migráció során problémákba ütközik, kérjük, vegye fel a kapcsolatot az [Aspose támogatással](https://forum.aspose.com/) a további segítségért.