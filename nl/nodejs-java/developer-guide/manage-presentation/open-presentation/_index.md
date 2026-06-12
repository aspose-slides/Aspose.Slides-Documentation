---
title: Presentaties openen in JavaScript
linktitle: Presentatie openen
type: docs
weight: 20
url: /nl/nodejs-java/open-presentation/
keywords:
- PowerPoint openen
- OpenDocument openen
- presentatie openen
- PPTX openen
- PPT openen
- ODP openen
- presentatie laden
- PPTX laden
- PPT laden
- ODP laden
- beveiligde presentatie
- grote presentatie
- externe bron
- binair object
- Node.js
- JavaScript
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) en OpenDocument (.odp) presentaties moeiteloos met Aspose.Slides voor Node.js via Java - snel, betrouwbaar, volledig uitgerust."
---
## **Introductie**

Naast het van nul af aan maken van PowerPoint‑presentaties, stelt Aspose.Slides je ook in staat bestaande presentaties te openen. Nadat je een presentatie hebt geladen, kun je informatie erover opvragen, de inhoud van dia’s bewerken, nieuwe dia’s toevoegen, bestaande dia’s verwijderen en meer.

## **Presentaties openen**

Om een bestaande presentatie te openen, instantieer je de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse en geef je het bestandspad aan de constructor.

Het volgende JavaScript‑voorbeeld laat zien hoe je een presentatie opent en het aantal dia’s opvraagt:

```js
// Instantieer de Presentation-klasse en geef een bestandspad door aan de constructor.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Print het totale aantal dia's in de presentatie.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Wachtwoordbeveiligde presentaties openen**

Wanneer je een wachtwoordbeveiligde presentatie moet openen, geef je het wachtwoord door aan de [setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword)‑methode van de [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/)‑klasse om deze te ontcijferen en te laden. De volgende JavaScript‑code demonstreert deze handeling:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Voer bewerkingen uit op de ontcijferde presentatie.
} finally {
    presentation.dispose();
}
```

## **Grote presentaties openen**

Aspose.Slides biedt opties — met name de [getBlobManagementOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions)‑methode in de [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/)‑klasse — om grote presentaties te laden.

De volgende JavaScript‑code laat zien hoe je een grote presentatie laadt (bijvoorbeeld 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Kies het KeepLocked‑gedrag — het presentatiebestand blijft vergrendeld gedurende de levensduur van
// de Presentation‑instantie, maar het hoeft niet in het geheugen geladen te worden of gekopieerd naar een tijdelijk bestand.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // De grote presentatie is geladen en kan worden gebruikt, terwijl het geheugenverbruik laag blijft.
    
    // Breng wijzigingen aan in de presentatie.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Sla de presentatie op in een ander bestand. Het geheugenverbruik blijft laag tijdens deze bewerking.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Doe dit niet! Er wordt een I/O‑exception opgegooid omdat het bestand vergrendeld is tot het presentatiewerkobject wordt vrijgegeven.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Het is hier wel toegestaan. Het bronbestand is niet langer vergrendeld door het presentatiewerkobject.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
Om bepaalde beperkingen bij het gebruik van streams te omzeilen, kan Aspose.Slides de inhoud van een stream kopiëren. Het laden van een grote presentatie vanuit een stream zorgt ervoor dat de presentatie wordt gekopieerd, wat het laden kan vertragen. Daarom raden we, wanneer je een grote presentatie moet laden, sterk aan om het bestandspad van de presentatie te gebruiken in plaats van een stream.

Wanneer je een presentatie maakt die grote objecten bevat (video, audio, afbeeldingen met hoge resolutie, enz.), kun je [BLOB‑beheer](/slides/nl/nodejs-java/manage-blob/) gebruiken om het geheugenverbruik te verlagen.
{{%/alert %}}

## **Externe bronnen beheren**

Aspose.Slides biedt de [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iresourceloadingcallback/)‑interface waarmee je externe bronnen kunt beheren. De volgende JavaScript‑code laat zien hoe je de `IResourceLoadingCallback`‑interface gebruikt:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Laad een vervangende afbeelding.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Stel een vervangende URL in.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Sla alle andere afbeeldingen over.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Presentaties laden zonder ingesloten binaire objecten**

Een PowerPoint‑presentatie kan de volgende soorten ingesloten binaire objecten bevatten:

- VBA‑project (toegankelijk via [Presentation.getVbaProject](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getVbaProject));
- OLE‑object ingesloten data (toegankelijk via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ActiveX‑besturingselement binaire data (toegankelijk via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Met de [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects)‑methode kun je een presentatie laden zonder enige ingesloten binaire objecten.

Deze methode is handig om potentieel schadelijke binaire inhoud te verwijderen. De volgende JavaScript‑code demonstreert hoe je een presentatie laadt zonder enige ingebedde binaire inhoud:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Voer bewerkingen uit op de presentatie.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Hoe kan ik zien dat een bestand corrupt is en niet geopend kan worden?**

Tijdens het laden krijg je een parser‑/formaat‑validatie‑exception. Dergelijke fouten vermelden vaak een ongeldige ZIP‑structuur of beschadigde PowerPoint‑records.

**Wat gebeurt er als vereiste lettertypen ontbreken bij het openen?**

Het bestand wordt geopend, maar later kan [renderen/exporteren](/slides/nl/nodejs-java/convert-presentation/) de lettertypen vervangen. [Configureer lettertype‑substituties](/slides/nl/nodejs-java/font-substitution/) of [voeg de vereiste lettertypen toe](/slides/nl/nodejs-java/custom-font/) aan de runtime‑omgeving.

**Hoe zit het met ingebedde media (video/audio) bij het openen?**

Deze worden beschikbaar als presentatieresources. Als media via externe paden worden verwezen, zorg dan dat die paden toegankelijk zijn in je omgeving; anders kan [renderen/exporteren](/slides/nl/nodejs-java/convert-presentation/) de media weglaten.