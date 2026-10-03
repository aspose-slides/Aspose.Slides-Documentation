---
title: Vereisten voor Security Manager
type: docs
weight: 190
url: /nl/java/declaration/
keywords:
- Security Manager
- beveiligingsbeleid
- AllPermission
- permissies
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Welke Security Manager-permissies Aspose.Slides for Java en de code die het aanroept nodig hebben op Java 23 en ouder, en waarom er niets te configureren is op Java 24 en later."
---
## **Overzicht**

De Java Security Manager beperkt wat code mag doen volgens een beveiligingsbeleid. Java 17 heeft deze gemarkeerd voor verwijdering ([JEP 411](https://openjdk.org/jeps/411)), en Java 24 heeft deze permanent uitgeschakeld ([JEP 486](https://openjdk.org/jeps/486)). Dit artikel legt uit wat Aspose.Slides for Java nodig heeft wanneer een applicatie nog steeds met een Security Manager draait. Als uw applicatie er geen inschakelt, wat standaard is, hoeft u niets te configureren.

## **Java 23 en ouder**

Wanneer een Security Manager is ingeschakeld, moet het beveiligingsbeleid deze permissies verlenen aan het Aspose.Slides‑JAR‑bestand en aan de toepassingscode die het aanroept:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides leest systeemeigenschappen.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides leest lettertype‑bestanden en andere bestanden.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides start besturingssysteem‑programma’s, bijvoorbeeld `reg` op Windows en `fc-match` op Linux.
- `java.io.FilePermission` met de `write`‑actie voor de mappen waar uw applicatie bestanden opslaat.

Het alleen verlenen van de permissies aan het JAR‑bestand is niet voldoende: de code die Aspose.Slides aanroept heeft ze ook nodig. Het verlenen van `java.security.AllPermission` aan beide werkt ook.

Zonder de permissie om systeemeigenschappen te lezen of om programma’s te starten, mislukt Aspose.Slides bij eerste gebruik: het aanmaken van een [Presentatie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑object gooit een `ExceptionInInitializerError`. Zonder leesrechten op de lettertype‑bestanden mislukt het opslaan van een presentatie als PDF met de fout “Cannot find any fonts installed on the system”.

## **Java 24 en later**

De Security Manager kan niet worden ingeschakeld in Java 24 en later, dus er zijn geen permissies om toe te kennen. Aspose.Slides draait met de rechten van het account dat uw applicatie uitvoert. Om te beperken wat een applicatie mag benaderen, beveelt het OpenJDK‑project technologieën buiten de JDK aan, zoals containers, hypervisors en sandbox‑functies van het besturingssysteem. Zie [JEP 486](https://openjdk.org/jeps/486).

## **FAQ**

**Kan ik Aspose.Slides gebruiken in een omgeving waarin applicaties draaien onder een restrictief Security Manager‑beleid?**

Alleen als het beleid de hierboven genoemde permissies verleent zowel aan Aspose.Slides als aan de code die het aanroept. Deze omvatten het lezen van alle bestanden en het starten van elk programma.