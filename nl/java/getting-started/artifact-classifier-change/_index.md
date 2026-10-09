---
title: Declaratie
type: docs
weight: 60
url: /nl/java/artifact-classifier-change/
keywords:
- classifier Aspose.Slides
- artifact classifier
- gebruik Aspose.Slides
- installatie van Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Aspose.Slides voor Java gebruikt nu de jdk8-classifier in plaats van jdk16. Leer waarom en hoe u uw afhankelijkheden kunt bijwerken."
---
## **Wijziging van Artifact Classifier van `jdk16` naar `jdk8`**

Vanaf versie **26.10** hebben we de classifier die wordt gebruikt in onze gepubliceerde artefacten gewijzigd van **`jdk16`** (Java 6) naar **`jdk8`** (Java 8).

### **Wat is veranderd**

| | Voor | Na |
|---|---|---|
| Classifier | `jdk16` | `jdk8` |
| Minimum Java‑versie | Java 1.6 | Java 8 |

**Voor:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Na:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Waarom we deze wijziging hebben doorgevoerd**

Na intern onderzoek hebben we besloten om **ondersteuning voor oudere Java‑versies** te beëindigen, die geen waarde meer leverden en het onderhoud actief belemmerden. Java 8 werd gekozen als de nieuwe, veilige basislijn voor alle gebruikers.

Als onderdeel hiervan werd de classifier bijgewerkt om de werkelijke minimum ondersteunde versie weer te geven. We hebben ook afgestemd op de huidige Oracle‑naamgeving, waarbij het product officieel wordt aangeduid als **JDK 8** (in plaats van het legacy `1.8`‑formaat).

### **Wat je moet doen**

1. **Update de classifier** in je afhankelijkheidsdeclares van `jdk16` naar `jdk8`.

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

2. **Controleer je runtime‑omgeving**; deze moet Java 8 of hoger zijn.

3. **Vernieuw eventuele lock‑bestanden** of afhankelijkheids‑caches die de oude classifier vastzetten.

### **Migratienotitie: jdk16 en jdk8**

Vanaf versie 26.10 zullen zowel de jdk16- als de jdk8‑classifiers Java 8‑compatibele JAR‑bestanden leveren (gebouwd met source/target‑compatibiliteit ingesteld op Java 8).

- `jdk16` → blijft gepubliceerd voor achterwaartse compatibiliteit (bestaande integraties).
- `jdk8` → geïntroduceerd als de nieuwe voorkeurs‑classifier voor Java 8‑omgevingen.

⚠️ Opmerking: deze fase van dubbele publicatie loopt tot 31 maart 2027. Na deze datum wordt de jdk16‑classifier beëindigd en wordt alleen jdk8 ondersteund.

### **Compatibiliteitsnotities**

- De `jdk16`‑classifier is **niet meer gepubliceerd** na **31 maart 2027**.
- Als je nog Java 1.6‑ondersteuning nodig hebt, blijf dan op de vorige hoofdversielijn tot je kunt migreren.

### **Hulp nodig?**

Als je problemen ondervindt tijdens de migratie, neem dan contact op met [Aspose‑ondersteuning](https://forum.aspose.com/) voor verdere hulp.