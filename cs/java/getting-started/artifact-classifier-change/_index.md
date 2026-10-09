---
title: Deklarace
type: docs
weight: 60
url: /cs/java/artifact-classifier-change/
keywords:
- klasifikátor Aspose.Slides
- klasifikátor artefaktu
- použít Aspose.Slides
- instalace Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Aspose.Slides pro Javu nyní používá klasifikátor jdk8 místo jdk16. Zjistěte proč a jak aktualizovat své závislosti."
---
## Změna klasifikátoru artefaktu z `jdk16` na `jdk8`

Starting with version **26.10**, we have changed the classifier used in our published artifacts from **`jdk16`** (Java 6) to **`jdk8`** (Java 8).

### Co se změnilo

| | Před | Po |
|---|---|---|
| Klasifikátor | `jdk16` | `jdk8` |
| Minimální verze Javy | Java 1.6 | Java 8 |

**Před:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Po:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### Proč jsme tuto změnu provedli

Po interním přezkoumání jsme se rozhodli **zrušit podporu starších verzí Javy**, které již nepřinášely hodnotu a aktivně bránily údržbě. Java 8 byla vybrána jako nová, bezpečná základna pro všechny uživatele.

V rámci toho byl klasifikátor aktualizován, aby odrážel skutečnou minimální podporovanou verzi. Také jsme se sladili s aktuální konvencí pojmenování od Oracle, kde je produkt oficiálně označován jako **JDK 8** (namísto starého formátu `1.8`).

### Co musíte udělat

1. **Aktualizujte klasifikátor** ve svých deklaracích závislostí z `jdk16` na `jdk8`.

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

2. **Ověřte, že vaše běhové prostředí** je Java 8 nebo vyšší.

3. **Obnovte jakékoli soubory zámků** nebo mezipaměti závislostí, které připínají starý klasifikátor.

### Poznámka k migraci: jdk16 a jdk8

Od verze 26.10​ budou oba klasifikátory jdk16 i jdk8 poskytovat JAR soubory kompatibilní s Java 8 (s nastavenou kompatibilitou zdroje/cíle na Java 8).

- `jdk16` → bude nadále publikován pro zpětnou kompatibilitu (existující integrace).
- `jdk8` → byl zaveden jako nový preferovaný klasifikátor pro prostředí Java 8.

⚠️ Poznámka: Tato fáze dvojího publikování je naplánována k ukončení 31. března 2027​. Po tomto datu bude klasifikátor jdk16 vyřazen a bude podporován pouze jdk8.

### Poznámky o kompatibilitě

- Klasifikátor `jdk16` **již není publikován** po **31. března 2027**.
- Pokud stále potřebujete podporu Java 1.6, zůstaňte na předchozí hlavní verzi, dokud nebudete moci migrovat.

### Potřebujete pomoc?

Pokud během migrace narazíte na problémy, kontaktujte prosím [podporu Aspose](https://forum.aspose.com/) pro další pomoc.