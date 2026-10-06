---
title: Aan de slag
type: docs
weight: 10
url: /nl/java/getting-started/
keywords:
- aan de slag
- systeemeisen
- installatie
- eerste presentatie
- Maven
- PPT-verwerking
- PPTX-verwerking
- ODP-verwerking
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Het traject van een nieuw Java-project tot een eerst opgeslagen presentatie met Aspose.Slides: controleer de vereisten, voeg de bibliotheek toe vanuit Aspose's Maven-repository, voer een eerste programma uit, en ga door met veelvoorkomende taken."
---
## **Overzicht**

Doorloop de vier onderstaande stappen in volgorde. Elke stap geeft aan wat te doen en linkt naar het artikel met de details. Evaluatie, licenties en ondersteuning worden behandeld na de stappen.

## **Stap 1: Controleer de systeemvereisten**

Aspose.Slides for Java is één JAR‑bestand zonder native code, dus het draait op elk besturingssysteem met een ondersteunde Java‑runtime. [Systeemeisen](/slides/nl/java/system-requirements/) geeft de ondersteunde besturingssystemen en Java‑versies weer. Het project en de opdrachten in de volgende stappen hebben JDK 11 of hoger nodig en, voor de Maven‑route, [Apache Maven](https://maven.apache.org/install.html).

## **Stap 2: Voeg de bibliotheek toe aan uw project**

Aspose.Slides for Java wordt gepubliceerd in Aspose’s eigen Maven‑repository, niet in Maven Central. Kies een van deze routes:

- Met Maven: declareer de repository `https://releases.aspose.com/java/repo/` in uw *pom.xml* en voeg de afhankelijkheid `com.aspose:aspose-slides` toe met de `jdk16`‑classifier.
- Zonder Maven: download het JAR‑bestand dat eindigt op *-jdk16.jar* uit de repository en plaats het op het class‑path.

Op Linux moet u ook de fontconfig‑bibliotheek en minstens één lettertype installeren. Zonder deze mislukt het opslaan van een presentatie met de fout “Fontconfig head is null, check your fonts or fonts configuration”.

[Installatie](/slides/nl/java/installation/) geeft de *pom.xml*‑vermeldingen, de JAR‑download en de Linux‑opdracht.

## **Stap 3: Maak uw eerste presentatie**

De [quick start op de Aspose.Slides for Java startpagina](/slides/nl/java/#your-first-presentation) is een volledig Maven‑project: een *pom.xml*‑bestand en een programma dat een wolk‑vorm met tekst toevoegt aan een dia en de presentatie opslaat als een PPTX‑bestand. U voert het uit met `mvn compile exec:java`. [Presentaties maken](/slides/nl/java/create-presentation/) legt hetzelfde programma stap voor stap uit. Om een bestaande presentatie te openen en op te slaan in een ander formaat, zie [Presentaties openen](/slides/nl/java/open-presentation/) en [Presentaties opslaan](/slides/nl/java/save-presentation/).

## **Stap 4: Ga verder met veelvoorkomende taken**

- [Een presentatie openen](/slides/nl/java/open-presentation/)
- [Een presentatie opslaan](/slides/nl/java/save-presentation/)
- [Een presentatie omzetten naar PDF](/slides/nl/java/convert-powerpoint-to-pdf/)
- [Dia’s renderen als afbeeldingen](/slides/nl/java/convert-slide/)
- [Presentatietekst bewerken](/slides/nl/java/manage-text/)
- [Voorbeelden per diavorm](/slides/nl/java/examples/)

## **Evalueren en licentiëren**

Zonder licentie draait Aspose.Slides in evaluatiemodus: er wordt een watermerk op elke dia gezet die wordt opgeslagen en wordt tekst die uw code uit presentaties leest afgekapt.

- [Aspose.Slides evalueren](/slides/nl/java/evaluate-aspose-slides/) beschrijft de evaluatiebeperkingen en hoe u een tijdelijke licentie kunt aanvragen.
- [Licenseren](/slides/nl/java/licensing/) laat zien hoe u een licentie vanuit een bestand of een stream toepast.
- [Metered licenseren](/slides/nl/java/metered-licensing/) behandelt licenseren op basis van gebruik.
- [Ondersteunde bestandsformaten](/slides/nl/java/supported-file-formats/) somt de formaten op die Aspose.Slides kan laden en opslaan.

## **Hulp krijgen**

[Technische ondersteuning](/slides/nl/java/technical-support/) legt uit hoe u een vraag kunt stellen op het [gratis ondersteuningsforum](https://forum.aspose.com/c/slides/nl/11) en wat u moet meedelen bij het melden van een probleem.

## **FAQ**

**Moet ik Microsoft PowerPoint geïnstalleerd hebben?**

Nee. Aspose.Slides leest en schrijft presentatiebestanden zelf en gebruikt PowerPoint niet, zodat het ook op servers en op Linux draait.

**Waarom vindt Maven Aspose.Slides for Java niet?**

De bibliotheek staat niet in Maven Central. Declareer Aspose’s repository in uw *pom.xml*, zoals getoond in [Installatie](/slides/nl/java/installation/), en Maven downloadt de bibliotheek van daar.

**Betekent de `jdk16`‑classifier dat de bibliotheek Java 16 nodig heeft?**

Nee. De classifier kiest de Java SE‑build van de bibliotheek; de andere build is voor Android. dezelfde build draait op huidige JDK’s, zoals JDK 21.