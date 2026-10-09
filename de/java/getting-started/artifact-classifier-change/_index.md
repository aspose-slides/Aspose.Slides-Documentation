---
title: Deklaration
type: docs
weight: 60
url: /de/java/artifact-classifier-change/
keywords:
- classifier Aspose.Slides
- Artefakt-Klassifikator
- Verwendung von Aspose.Slides
- Aspose.Slides-Installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Aspose.Slides für Java verwendet jetzt den jdk8-Klassifikator anstelle von jdk16. Erfahren Sie, warum und wie Sie Ihre Abhängigkeiten aktualisieren."
---
## Änderung des Artefaktklassifikators von `jdk16` zu `jdk8`

Ab Version **26.10** haben wir den in unseren veröffentlichten Artefakten verwendeten Klassifikator von **`jdk16`** (Java 6) zu **`jdk8`** (Java 8) geändert.

### Was geändert wurde

| | Vorher | Nachher |
|---|---|---|
| Klassifikator | `jdk16` | `jdk8` |
| Mindest-Java-Version | Java 1.6 | Java 8 |

**Vorher:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Nachher:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### Warum wir diese Änderung vorgenommen haben

Nach einer internen Überprüfung haben wir beschlossen, **die Unterstützung für ältere Java-Versionen einzustellen**, die keinen Mehrwert mehr bieten und die Wartung aktiv behinderten. Java 8 wurde als neue, sichere Basis für alle Anwender ausgewählt.

Im Rahmen dessen wurde der Klassifikator aktualisiert, um die tatsächlich unterstützte Mindestversion widerzuspiegeln. Wir haben uns zudem an der aktuellen Oracle‑Namenskonvention orientiert, bei der das Produkt offiziell als **JDK 8** bezeichnet wird (statt dem veralteten Format `1.8`).

### Was Sie tun müssen

1. **Aktualisieren Sie den Klassifikator** in Ihren Abhängigkeitsdeklarationen von `jdk16` zu `jdk8`.

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

2. **Überprüfen Sie, dass Ihre Laufzeitumgebung** Java 8 oder höher ist.

3. **Aktualisieren Sie alle Sperrdateien** oder Abhängigkeits‑Caches, die den alten Klassifikator festlegen.

### Migrationshinweis: jdk16 und jdk8

Ab Version 26.10 bieten sowohl die jdk16‑ als auch die jdk8‑Klassifikatoren Java‑8‑kompatible JARs (erstellt mit Quell‑/Ziel‑Kompatibilität auf Java 8 eingestellt).

- `jdk16` → wird weiterhin aus Gründen der Rückwärtskompatibilität veröffentlicht (bestehende Integrationen).
- `jdk8` → wird als neuer bevorzugter Klassifikator für Java‑8‑Umgebungen eingeführt.

⚠️ Hinweis: Diese Phase des dualen Veröffentlichens ist für den 31. März 2027 geplant. Nach diesem Datum wird der jdk16‑Klassifikator eingestellt und nur noch jdk8 wird unterstützt.

### Kompatibilitäts‑Hinweise

- Der `jdk16`‑Klassifikator wird **nach dem 31. März 2027 nicht mehr veröffentlicht**.
- Wenn Sie weiterhin Java 1.6‑Unterstützung benötigen, bleiben Sie bitte auf der vorherigen Hauptversionslinie, bis Sie migrieren können.

### Benötigen Sie Hilfe?

Wenn Sie während der Migration auf Probleme stoßen, kontaktieren Sie bitte den [Aspose‑Support](https://forum.aspose.com/) für weitere Unterstützung.