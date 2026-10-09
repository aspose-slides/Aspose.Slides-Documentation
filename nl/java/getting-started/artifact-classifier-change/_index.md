---
title: Verklaring
type: docs
weight: 60
url: /nl/java/artifact-classifier-change/
keywords:
- classificatie Aspose.Slides
- artifact classificatie
- gebruik Aspose.Slides
- Aspose.Slides installatie
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Aspose.Slides voor Java gebruikt nu de jdk8‑classifier in plaats van jdk16. Leer waarom en hoe u uw afhankelijkheden bijwerkt."
---
## Artifact‑classifierwijziging van `jdk16` naar `jdk8`

Vanaf versie **26.10** hebben we de classifier die we in onze gepubliceerde artifacts gebruiken gewijzigd van **`jdk16`** (Java 6) naar **`jdk8`** (Java 8).

### Wat is er gewijzigd

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

### Waarom we deze wijziging hebben aangebracht

Na een interne beoordeling hebben we besloten om **ondersteuning voor oudere Java‑versies** te beëindigen, die geen waarde meer leverden en het onderhoud actief belemmerden. Java 8 is gekozen als de nieuwe, veilige basis voor alle gebruikers.

In dit kader is de classifier bijgewerkt om de feitelijke minimaal ondersteunde versie weer te geven. We hebben ons ook afgestemd op de huidige Oracle‑namingsconventie, waarbij het product officieel wordt aangeduid als **JDK 8** (in plaats van het verouderde `1.8`‑formaat).

### Wat u moet doen

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

3. **Ververs alle lock‑bestanden** of afhankelijkheids‑caches die de oude classifier vastzetten.

### Migratienotitie: jdk16 en jdk8

Vanaf versie 26.10​ zullen zowel de jdk16‑ als de jdk8‑classifiers Java 8‑compatibele JAR‑bestanden leveren (gebouwd met bron‑/doel‑compatibiliteit ingesteld op Java 8).

- `jdk16` → blijft gepubliceerd voor achterwaartse compatibiliteit (bestaande integraties).
- `jdk8` → geïntroduceerd als de nieuwe voorkeur‑classifier voor Java 8‑omgevingen.

⚠️ Opmerking: deze fase van dubbele publicatie eindigt op 31 maart 2027​. Na deze datum wordt de jdk16‑classifier uitgefaseerd en wordt alleen jdk8 ondersteund.

### Compatibiliteitsopmerkingen

- De `jdk16`‑classifier wordt **niet meer gepubliceerd** na **31 maart 2027**.
- Als u nog steeds Java 1.6‑ondersteuning nodig heeft, blijf dan op de vorige hoofdversielijn totdat u kunt migreren.

### Hulp nodig?

Als u problemen ondervindt tijdens de migratie, neem dan contact op met [Aspose‑ondersteuning](https://forum.aspose.com/) voor verdere hulp.