---
title: Änderung des Artifact-Klassifikators
type: docs
weight: 60
url: /de/java/artifact-classifier-change/
keywords:
- Klassifikator Aspose.Slides
- Artifact Klassifikator
- Verwendung von Aspose.Slides
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
## **Änderung des Artifact‑Klassifikators von `jdk16` zu `jdk8`**

Ab Version **26.10** haben wir den in unseren veröffentlichten Artefakten verwendeten Klassifikator von **`jdk16`** (Java 6) zu **`jdk8`** (Java 8) geändert.

### **Was geändert wurde**

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

### **Warum wir diese Änderung vorgenommen haben**

Nach einer internen Überprüfung haben wir beschlossen, die **Unterstützung für ältere Java-Versionen** einzustellen, da diese keinen Mehrwert mehr bieten und die Wartung aktiv erschweren. Java 8 wurde als neue, sichere Basis für alle Anwender ausgewählt.

Im Rahmen dessen wurde der Klassifikator aktualisiert, um die tatsächlich unterstützte Mindestversion widerzuspiegeln. Wir haben uns zudem an die aktuelle Benennungs‑Konvention von Oracle angepasst, bei der das Produkt offiziell **JDK 8** (statt des alten `1.8`‑Formats) genannt wird.

### **Was Sie tun müssen**

1. **Klassifikator aktualisieren** in Ihren Abhängigkeitsdeklarationen von `jdk16` zu `jdk8`.

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

2. **Laufzeitumgebung überprüfen** ist Java 8 oder höher.

3. **Alle Sperrdateien aktualisieren** oder Abhängigkeits‑Caches, die den alten Klassifikator festlegen.

### **Migrationshinweis: jdk16 und jdk8**

Ab Version 26.10 stellen sowohl die Klassifikatoren jdk16 als auch jdk8 Java 8‑kompatible JARs bereit (gebaut mit Quell‑/Zielkompatibilität auf Java 8 eingestellt).

- `jdk16` → wird weiterhin aus Gründen der Rückwärtskompatibilität veröffentlicht (bestehende Integrationen).
- `jdk8` → wird als neuer bevorzugter Klassifikator für Java 8‑Umgebungen eingeführt.

⚠️ Hinweis: Diese Phase der Dual‑Veröffentlichung ist geplant, am 31. März 2027 zu enden. Nach diesem Datum wird der Klassifikator jdk16 eingestellt und nur jdk8 wird unterstützt.

### **Kompatibilitäts‑Hinweise**

- Der `jdk16`‑Klassifikator ist **nicht mehr veröffentlicht** nach **31. März 2027**.
- Wenn Sie weiterhin Java 1.6‑Unterstützung benötigen, bleiben Sie bitte auf der vorherigen Hauptversionslinie, bis Sie migrieren können.

### **Brauchen Sie Hilfe?**

Wenn Sie während der Migration Probleme haben, kontaktieren Sie bitte den [Aspose‑Support](https://forum.aspose.com/) für weitere Unterstützung.