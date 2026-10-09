---
title: Wijziging van artifactclassificatie
type: docs
weight: 60
url: /nl/java/artifact-classifier-change/
keywords:
- classificatie Aspose.Slides
- artifactclassificatie
- gebruik Aspose.Slides
- installatie Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Aspose.Slides voor Java gebruikt nu de jdk8-classifier in plaats van jdk16. Lees waarom en hoe u uw afhankelijkheden bijwerkt."
---
## **Verandering van artifactclassificatie van `jdk16` naar `jdk8`**

Vanaf versie **26.10** hebben we de classifier die in onze gepubliceerde artifacts wordt gebruikt aangepast van **`jdk16`** (Java 6) naar **`jdk8`** (Java 8).

### **Wat is er veranderd**

| | Voor | Na |
|---|---|---|
| Classificatie | `jdk16` | `jdk8` |
| Minimale Java‑versie | Java 1.6 | Java 8 |

**Voor:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Na:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Waarom we deze wijziging hebben doorgevoerd**

Na een interne beoordeling hebben we besloten om **ondersteuning voor oudere Java‑versies** te stoppen, omdat deze geen waarde meer leverden en het onderhoud belemmerden. Java 8 werd gekozen als de nieuwe, veilige basis voor alle gebruikers.

Als onderdeel hiervan werd de classifier bijgewerkt om de werkelijke minimaal ondersteunde versie weer te geven. We stemden ook af op de huidige Oracle‑naamgevingsconventie, waarbij het product officieel wordt aangeduid als **JDK 8** (in plaats van het verouderde `1.8`‑formaat).

### **Wat u moet doen**

1. **Werk de classifier bij** in uw afhankelijkheidsverklaringen van `jdk16` naar `jdk8`.

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

2. **Controleer of uw runtime‑omgeving** Java 8 of hoger is.

3. **Ververs eventuele lock‑bestanden** of afhankelijkheids‑caches die de oude classifier vastzetten.

### **Migratienota: jdk16 en jdk8**

Vanaf versie 26.10​ zullen zowel de jdk16‑ als de jdk8‑classifiers Java 8‑compatibele JAR‑bestanden leveren (gebouwd met bron‑/doel‑compatibiliteit ingesteld op Java 8).

- `jdk16` → wordt voortgezet gepubliceerd voor achterwaartse compatibiliteit (bestaande integraties).
- `jdk8` → geïntroduceerd als de nieuwe voorkeur‑classifier voor Java 8‑omgevingen.

⚠️ Opmerking: Deze fase van dubbele publicatie eindigt op 31 maart 2027​. Na deze datum wordt de jdk16‑classifier beëindigd, en alleen jdk8 zal worden ondersteund.

### **Compatibiliteitsopmerkingen**

- De `jdk16`‑classifier wordt **niet meer gepubliceerd** na **31 maart 2027**.
- Als u nog steeds Java 1.6‑ondersteuning nodig heeft, blijf dan op de vorige hoofdversielijn totdat u kunt migreren.

### **Hulp nodig?**

Als u tijdens de migratie problemen ondervindt, neem dan contact op met [Aspose‑ondersteuning](https://forum.aspose.com/) voor verdere hulp.