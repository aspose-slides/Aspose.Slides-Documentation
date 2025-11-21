---
title: En-tête et pied de page de la présentation
type: docs
weight: 140
url: /fr/nodejs-java/presentation-header-and-footer/
keywords: "En-tête et pied de page PowerPoint en JavaScript"
description: "En-tête et pied de page PowerPoint en JavaScript"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/fr/nodejs-java/) fournit une prise en charge pour travailler avec le texte des en‑têtes et pieds de page des diapositives qui sont effectivement maintenus au niveau du maître de diapositive.

{{% /alert %}} 

[Aspose.Slides for Node.js via Java](/slides/fr/nodejs-java/) fournit la fonctionnalité de gestion des en‑têtes et pieds de page à l'intérieur des diapositives de présentation. Ceux‑ci sont en fait gérés au niveau du maître de présentation.

## **Gérer les en‑têtes et pieds de page dans la présentation**
Les notes d’une diapositive spécifique peuvent être supprimées comme illustré dans l’exemple ci‑dessous :
```javascript
// Charger la présentation
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Définir le pied de page
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Accéder et mettre à jour l'en-tête
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Enregistrer la présentation
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **Gérer les en‑têtes et pieds de page dans les diapositives de version imprimée et de notes**
Aspose.Slides for Node.js via Java prend en charge les en‑têtes et pieds de page dans les diapositives de version imprimée et de notes. Veuillez suivre les étapes ci‑dessous :

- Chargez une [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) contenant une vidéo.
- Modifiez les paramètres d’en‑tête et de pied de page pour le maître des notes et toutes les diapositives de notes.
- Rendez visibles le maître de la diapositive de notes et tous les espaces réservés de pied de page enfants.
- Rendez visibles le maître de la diapositive de notes et tous les espaces réservés de date et d’heure enfants.
- Modifiez les paramètres d’en‑tête et de pied de page uniquement pour la première diapositive de notes.
- Rendez visible l’espace réservé d’en‑tête de la diapositive de notes.
- Définissez le texte de l’espace réservé d’en‑tête de la diapositive de notes.
- Définissez le texte de l’espace réservé de date‑heure de la diapositive de notes.
- Enregistrez le fichier de présentation modifié.

Extrait de code fourni dans l’exemple ci‑dessous.
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Modifier les paramètres d’en-tête et de pied de page pour le maître des notes et toutes les diapositives de notes
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// rendre la diapositive maître des notes et tous les espaces réservés de pied de page enfants visibles
        headerFooterManager.setFooterAndChildFootersVisibility(true);// rendre la diapositive maître des notes et tous les espaces réservés d’en-tête enfants visibles
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// rendre la diapositive maître des notes et tous les espaces réservés de numéro de diapositive enfants visibles
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// rendre la diapositive maître des notes et tous les espaces réservés de date et heure enfants visibles
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// définir le texte pour la diapositive maître des notes et tous les espaces réservés d’en-tête enfants
        headerFooterManager.setFooterAndChildFootersText("Footer text");// définir le texte pour la diapositive maître des notes et tous les espaces réservés de pied de page enfants
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// définir le texte pour la diapositive maître des notes et tous les espaces réservés de date et heure enfants
    }
    // Modifier les paramètres d’en-tête et de pied de page uniquement pour la première diapositive de notes
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// rendre cet espace réservé d’en-tête de diapositive de notes visible
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// rendre cet espace réservé de pied de page de diapositive de notes visible
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// rendre cet espace réservé de numéro de diapositive de diapositive de notes visible
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// rendre cet espace réservé de date-heure de diapositive de notes visible
        headerFooterManager.setHeaderText("New header text");// définir le texte pour l’espace réservé d’en-tête de la diapositive de notes
        headerFooterManager.setFooterText("New footer text");// définir le texte pour l’espace réservé de pied de page de la diapositive de notes
        headerFooterManager.setDateTimeText("New date and time text");// définir le texte pour l’espace réservé de date-heure de la diapositive de notes
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je ajouter un « en‑tête » aux diapositives ordinaires ?**

Dans PowerPoint, l’« en‑tête » n’existe que pour les notes et les versions imprimées ; sur les diapositives ordinaires, les éléments pris en charge sont le Footer, la DateTime et le SlideNumber. Dans Aspose.Slides, cela correspond aux mêmes limitations : en‑tête uniquement pour les Notes/Handout, et sur les diapositives — Footer/DateTime/SlideNumber.

**Que faire si la mise en page ne contient pas de zone de pied de page — puis‑je « activer » sa visibilité ?**

Oui. Vérifiez la visibilité via le gestionnaire d’en‑tête/pied de page et activez‑la si nécessaire. Ces indicateurs et méthodes d’API sont conçus pour les cas où l’espace réservé est manquant ou masqué.

**Comment faire commencer le numéro de diapositive à une valeur autre que 1 ?**

Définissez le [first slide number](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) de la présentation ; après cela, tous les numéros sont recalculés. Par exemple, vous pouvez commencer à 0 ou 10, et masquer le numéro sur la diapositive de titre.

**Que se passe‑t‑il avec les en‑têtes/pieds de page lors de l’exportation vers PDF/images/HTML ?**

Ils sont rendus comme des éléments de texte ordinaires de la présentation. C’est‑à‑dire, si les éléments sont visibles sur les diapositives ou les pages de notes, ils apparaîtront également dans le format de sortie avec le reste du contenu.