---
title: Deklaration
type: docs
weight: 60
url: /de/java/artifact-classifier-change/
keywords:
- Klassifikator Aspose.Slides
- Artifact-Klassifikator
- Aspose.Slides verwenden
- Aspose.Slides Installation
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
## **Änderung des Artefaktklassifikators von `jdk16` zu `jdk8`**

Ab Version **26.10** haben wir den in unseren veröffentlichten Artefakten verwendeten Klassifikator von **`jdk16`** (Java 6) zu **`jdk8`** (Java 8) geändert.

### **Was wurde geändert**

| | Vorher | Nachher |
|---|---|---|
| Klassifikator | `jdk16` | `jdk8` |
| Mindestens Java-Version | Java 1.6 | Java 8 |

**Vorher:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Nachher:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Warum wir diese Änderung vorgenommen haben**

Nach einer internen Überprüfung haben wir beschlossen, **die Unterstützung für ältere Java‑Versionen** einzustellen, die keinen Mehrwert mehr boten und die Wartung aktiv behinderten. Java 8 wurde als neue, sichere Basisversion für alle Anwender ausgewählt.

Im Rahmen dessen wurde der Klassifikator aktualisiert, um die tatsächlich unterstützte Mindestversion widerzuspiegeln. Außerdem haben wir uns an die aktuelle Benennungskonvention von Oracle angeglichen, bei der das Produkt offiziell als **JDK 8** bezeichnet wird (statt des veralteten Formats `1.8`).

### **Was Sie tun müssen**

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

2. **Vergewissern Sie sich, dass Ihre Laufzeitumgebung** Java 8 oder höher ist.

3. **Aktualisieren Sie alle Sperrdateien** oder Abhängigkeits‑Caches, die den alten Klassifikator festlegen.

### **Hinweis zur Migration: jdk16 und jdk8**

Ab Version 26.10 bieten sowohl die Klassifikatoren jdk16 als auch jdk8 Java 8‑kompatible JARs (gebaut mit Quell‑/Zielkompatibilität auf Java 8 eingestellt).

 - `jdk16` → wird weiterhin für Abwärtskompatibilität veröffentlicht (bestehende Integrationen).
 - `jdk8` → wird als neuer bevorzugter Klassifikator für Java 8‑Umgebungen eingeführt.

⚠️ Hinweis: Diese Phase des doppelten Veröffentlichens soll am 31. März 2027 enden. Nach diesem Datum wird der Klassifikator jdk16 eingestellt und nur jdk8 wird unterstützt.

### **Kompatibilitätshinweise**

- Der Klassifikator `jdk16` wird **nach dem 31. März 2027** nicht mehr veröffentlicht.
- Falls Sie weiterhin Java 1.6‑Unterstützung benötigen, bleiben Sie bitte bis zur Migration auf der vorherigen Hauptversionslinie.

### **Brauchen Sie Hilfe?**

Wenn Sie während der Migration auf Probleme stoßen, kontaktieren Sie bitte den [Aspose‑Support](https://forum.aspose.com/) für weitere Unterstützung.