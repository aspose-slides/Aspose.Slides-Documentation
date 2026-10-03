---
title: Požadavky Správce zabezpečení
type: docs
weight: 190
url: /cs/java/declaration/
keywords:
- Správce zabezpečení
- bezpečnostní politika
- AllPermission
- oprávnění
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Jaká oprávnění Správce zabezpečení potřebuje Aspose.Slides pro Java a kód, který jej volá, na Java 23 a starších, a proč není třeba nic konfigurovat na Java 24 a novějších."
---
## **Přehled**

Správce zabezpečení Java omezuje, co může kód dělat podle bezpečnostní politiky. Java 17 jej označila za zastaralý s úmyslem odebrat ([JEP 411](https://openjdk.org/jeps/411)), a Java 24 jej trvale vypnula ([JEP 486](https://openjdk.org/jeps/486)). Tento článek vysvětluje, co potřebuje Aspose.Slides pro Java, když aplikace stále běží se Správcem zabezpečení. Pokud vaše aplikace Správce zabezpečení nepovolí, což je výchozí nastavení, není co konfigurovat.

## **Java 23 a starší**

Když je Správce zabezpečení povolen, bezpečnostní politika musí udělit tyto oprávnění souboru JAR Aspose.Slides a aplikačnímu kódu, který jej volá:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides čte systémové vlastnosti.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides čte soubory písem a další soubory.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides spouští programy operačního systému, například `reg` ve Windows a `fc-match` v Linuxu.
- `java.io.FilePermission` s akcí `write` pro složky, kam vaše aplikace ukládá soubory.

Udělení oprávnění pouze souboru JAR není dostačující: kód, který volá Aspose.Slides, je také potřebuje. Udělení `java.security.AllPermission` oběma také funguje.

Bez oprávnění číst systémové vlastnosti nebo spouštět programy Aspose.Slides selže při prvním použití: vytvoření objektu [Prezentace](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) vyvolá `ExceptionInInitializerError`. Bez přístupu ke čtení souborů písem selže ukládání prezentace jako PDF s chybou "Nelze najít žádná písma nainstalovaná v systému".

## **Java 24 a novější**

Správce zabezpečení nelze na Java 24 a novějších povolit, takže není co udělovat. Aspose.Slides běží s oprávněními účtu, který spouští vaši aplikaci. Pro omezení toho, k čemu může aplikace přistupovat, projekt OpenJDK doporučuje technologie mimo JDK, jako jsou kontejnery, hypervisory a funkce sandboxingu operačního systému. Viz [JEP 486](https://openjdk.org/jeps/486).

## **Často kladené otázky**

**Mohu používat Aspose.Slides v prostředí, kde jsou aplikace spuštěny pod restriktivní politikou Správce zabezpečení?**

Pouze pokud politika udělí výše uvedená oprávnění jak Aspose.Slides, tak kódu, který jej volá. Patří mezi ně čtení všech souborů a spouštění jakéhokoli programu.