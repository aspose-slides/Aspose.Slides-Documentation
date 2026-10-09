---
title: Deklaráció
type: docs
weight: 60
url: /hu/java/artifact-classifier-change/
keywords:
- osztályozó Aspose.Slides
- artefakt osztályozó
- használja Aspose.Slides
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
## Az artefakt osztályozó változása `jdk16`-ról `jdk8`-ra

A **26.10** verziótól kezdve megváltoztattuk a közzétett artefaktokban használt osztályozót **`jdk16`** (Java 6) helyett **`jdk8`** (Java 8) használatára.

### Mi változott

| | Korábban | Most |
|---|---|---|
| Osztályozó | `jdk16` | `jdk8` |
| Minimális Java verzió | Java 1.6 | Java 8 |

**Korábban:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Most:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### Miért hajtottuk végre ezt a változást

Belső felülvizsgálat után úgy döntöttünk, hogy **eljárjuk a régebbi Java verziók támogatását**, amelyek már nem hoztak értéket, és aktívan akadályozták a karbantartást. A Java 8-at választottuk új, biztonságos kiindulási pontként minden felhasználó számára.

Ennek részeként frissítettük az osztályozót, hogy tükrözze a ténylegesen támogatott minimális verziót. Emellett egységesítettük a jelenlegi Oracle elnevezési konvencióval, ahol a terméket hivatalosan **JDK 8**‑ként nevezik (nem a régi `1.8` formátumként).

### Mit kell tennie

1. **Frissítse az osztályozót** a függőségdefiníciókban `jdk16`-ról `jdk8`-ra.

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

2. **Ellenőrizze a futtatási környezetét**, hogy Java 8 vagy újabb legyen.

3. **Frissítse az összes lock fájlt** vagy a függőségi cache-eket, amelyek a régi osztályozót rögzítik.

### Migrációs megjegyzés: jdk16 és jdk8

A 26.10‑es verziótól kezdve a jdk16 és a jdk8 osztályozók is Java 8‑kompatibilis JAR-okat fognak biztosítani (a forrás-/célkompatibilitás Java 8-ra van beállítva).

 - `jdk16` → továbbra is közzétett a visszafelé kompatibilitás érdekében (létező integrációk).
 - `jdk8` → bevezetve új, preferált **osztályozó**ként a Java 8 környezetekhez.

⚠️ Megjegyzés: Ez a kettős közzétételi fázis várhatóan 2027. március 31‑én ér véget. Ez után a jdk16 osztályozó megszűnik, és csak a jdk8 lesz támogatott.

### Kompatibilitási megjegyzések

- `jdk16` osztályozó **már nem kerül közzétételre** **2027. március 31.** után.
- Ha továbbra is Java 1.6 támogatásra van szüksége, kérjük, maradjon a korábbi **fő** verzióvonalon, amíg át tud váltani.

### Segítségre van szüksége?

Ha problémába ütközik a migráció során, kérjük, vegye fel a kapcsolatot az [Aspose support](https://forum.aspose.com/) csapatával a további segítségért.