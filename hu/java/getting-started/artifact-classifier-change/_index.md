---
title: Artefakt osztályozó változás
type: docs
weight: 60
url: /hu/java/artifact-classifier-change/
keywords:
- osztályozó Aspose.Slides
- artefakt osztályozó
- használja az Aspose.Slides
- Aspose.Slides telepítés
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
## **Az artefakt osztályozó változása `jdk16`-ról `jdk8`-ra**

A **26.10**-es verziótól megváltoztattuk a közzétett artefaktok osztályozóját **`jdk16`** (Java 6) helyett **`jdk8`** (Java 8) használatára.

### **Mi változott**

| | Korábban | Utána |
|---|---|---|
| Osztályozó | `jdk16` | `jdk8` |
| Minimális Java verzió | Java 1.6 | Java 8 |

**Korábban:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Utána:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Miért végeztük el a változtatást**

Belső felülvizsgálat után úgy döntöttünk, hogy **lemondjuk a régebbi Java verziók támogatását**, amelyek már nem nyújtanak értéket, és aktívan nehezítik a karbantartást. A Java 8-at választottuk új, biztonságos alapvonalnak minden felhasználó számára.

Ennek részeként az osztályozót frissítettük, hogy tükrözze a ténylegesen támogatott minimális verziót. Emellett igazodtunk a jelenlegi Oracle elnevezési konvencióhoz, amely szerint a terméket hivatalosan **JDK 8**-nak nevezik (a régi `1.8` formátum helyett).

### **Mit kell tennie**

1. **Frissítse az osztályozót** a függőségi deklarációkban `jdk16`-ról `jdk8`-ra.

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

2. **Ellenőrizze**, hogy a futtatási környezete Java 8 vagy újabb legyen.

3. **Frissítse a zárolófájlokat** vagy a függőséggyorsítótárakat, amelyek a régi osztályozót rögzítették.

### **Migrációs megjegyzés: jdk16 és jdk8**

A 26.10-es verziótól a **jdk16** és **jdk8** osztályozók egyaránt Java 8-kompatibilis JAR-okat biztosítanak (a forrás- /cél-kompatibilitás Java 8-ra van beállítva).

- `jdk16` → továbbra is közzétételre kerül a visszafelé kompatibilitás érdekében (létező integrációk).
- `jdk8` → új, preferált osztályozó Java 8 környezetekhez.

⚠️ **Megjegyzés:** Ez a kettős kiadási fázis 2027. március 31-én ér véget. Ezután a **jdk16** osztályozó megszűnik, és csak a **jdk8** lesz támogatott.

### **Kompatibilitási megjegyzések**

- A `jdk16` osztályozó **már nem kerül közzétételre** 2027. március 31. után.
- Amennyiben továbbra is Java 1.6 támogatásra van szüksége, maradjon a korábbi főverzió sorozatán, amíg a migráció nem lehetséges.

### **Segítségre van szüksége?**

Ha problémába ütközik a migráció során, kérjük, vegye fel a kapcsolatot az [Aspose támogatással](https://forum.aspose.com/) a további segítségért.