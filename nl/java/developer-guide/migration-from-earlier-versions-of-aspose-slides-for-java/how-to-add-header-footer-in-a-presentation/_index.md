---
title: Hoe kopteksten en voetteksten toe te voegen aan presentaties in Java
linktitle: Koptekst & Voettekst toevoegen
type: docs
weight: 20
url: /nl/java/how-to-add-header-footer-in-a-presentation/
keywords:
- migratie
- koptekst toevoegen
- voettekst toevoegen
- legacycode
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u kopteksten en voetteksten toevoegt in PowerPoint PPT, PPTX en ODP-presentaties in Java met zowel de legacy- als de moderne Aspose.Slides-API’s."
---
{{% alert color="info" %}} 

Er is een nieuwe [Aspose.Slides for Java API](https://docs.aspose.com/slides/nl/java/) uitgebracht en nu ondersteunt dit ene product de mogelijkheid om PowerPoint-documenten vanaf nul te genereren en bestaande documenten te bewerken.

{{% /alert %}} 
## **Ondersteuning voor legacy-code**
Om de legacy-code te gebruiken die ontwikkeld is met Aspose.Slides for Java-versies vóór 13.x, moet u enkele kleine aanpassingen in uw code doen en zal de code zoals eerder werken. Alle klassen die in de oude Aspose.Slides for Java onder de namespaces Aspose.Slide en Aspose.Slides.Pptx aanwezig waren, zijn nu samengevoegd in één Aspose.Slides-namespace. Bekijk de volgende eenvoudige code-snippet voor het toevoegen van kop en voettekst aan een presentatie in de legacy Aspose.Slides-API en volg de stappen die beschrijven hoe u migreert naar de nieuwe samengevoegde API.
## **Legacy-benadering van Aspose.Slides for Java**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **Nieuwe benadering van Aspose.Slides for Java 13.x**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}