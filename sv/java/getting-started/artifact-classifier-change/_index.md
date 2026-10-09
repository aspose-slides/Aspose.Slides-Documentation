---
title: Deklaration
type: docs
weight: 60
url: /sv/java/artifact-classifier-change/
keywords:
- klassificerare Aspose.Slides
- artefaktklassificerare
- använd Aspose.Slides
- Aspose.Slides-installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Aspose.Slides för Java använder nu jdk8-klassificeraren istället för jdk16. Läs varför och hur du uppdaterar dina beroenden."
---
## Ändring av artefaktklassificerare från `jdk16` till `jdk8`

Från och med version **26.10** har vi ändrat den klassificerare som används i våra publicerade artefakter från **`jdk16`** (Java 6) till **`jdk8`** (Java 8).

### Vad som ändrades

| | Före | Efter |
|---|---|---|
| Klassificerare | `jdk16` | `jdk8` |
| Minsta Java-version | Java 1.6 | Java 8 |

**Före:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Efter:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### Varför vi gjorde denna ändring

Efter intern granskning beslutade vi att **sluta stödja äldre Java-versioner** som inte längre gav något värde och som aktivt försvårade underhåll. Java 8 valdes som den nya, säkra baslinjen för alla konsumenter.

Som en del av detta uppdaterades klassificeraren för att återspegla den faktiska minsta stödda versionen. Vi anpassade oss också till det nuvarande Oracle-namnsystemet, där produkten officiellt kallas **JDK 8** (istället för det äldre `1.8`‑formatet).

### Vad du behöver göra

1. **Uppdatera klassificeraren** i dina beroendek declarationer från `jdk16` till `jdk8`.

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

2. **Verifiera att din körmiljö** är Java 8 eller högre.

3. **Uppdatera eventuella låsfiler** eller beroendecacher som pekar på den gamla klassificeraren.

### Migrationsanteckning: jdk16 och jdk8

Från version 26.10 kommer både jdk16‑ och jdk8‑klassificerarna att leverera Java 8‑kompatibla JAR‑filer (byggda med source/target‑kompatibilitet satt till Java 8).

- `jdk16` → fortsätter att publiceras för bakåtkompatibilitet (existerande integrationer).
- `jdk8` → introduceras som den nya föredragna klassificeraren för Java 8‑miljöer.

⚠️ Obs: Denna dubbla publiceringsfas är planerad att avslutas den 31 mars 2027. Efter detta datum kommer jdk16‑klassificeraren att avvecklas och endast jdk8 kommer att stödjas.

### Kompatibilitetsanteckningar

- Klassificeraren `jdk16` **publiceras inte längre** efter **31 mars 2027**.
- Om du fortfarande kräver stöd för Java 1.6, stanna kvar på den tidigare huvudversionslinjen tills du kan migrera.

### Behöver du hjälp?

Om du stöter på problem under migrationen, vänligen kontakta [Aspose-support](https://forum.aspose.com/) för ytterligare hjälp.