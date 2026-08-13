---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides for Java 15.5.0
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides for Java afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés et ainsi de suite [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/), ainsi que les nouvelles restrictions et autres [modifications](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) introduites avec l'API Aspose.Slides for Java 15.5.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **La classe CommonSlideViewProperties et l'interface ICommonSlideViewProperties ont été ajoutées**
La classe com.aspose.slides.CommonSlideViewProperties (et son interface com.aspose.slides.ICommonSlideViewProperties) représente les propriétés communes de la vue des diapositives (actuellement les options d'échelle de vue).
### **Les méthodes IAxis.getLabelOffset() et setLabelOffset(int) ont été ajoutées**
Les méthodes IAxis.getLabelOffset() et setLabelOffset(int) permettent d'obtenir et de spécifier la distance des étiquettes par rapport à l'axe. Applicables aux axes de catégorie ou de date.
### **Les méthodes IChartTextBlockFormat.getAutofitType() et setAutofitType(byte) ont été ajoutées**
Les méthodes getAutofitType() et setAutofitType(/**TextAutofitType**/byte) ont été ajoutées à l'interface com.aspose.slides.IChartTextBlockFormat.
La modification de cette valeur ne peut influencer que les éléments de graphique suivants : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2013 ; dans PowerPoint 2007 il n’y a aucun effet lors du rendu).
### **Les méthodes IChartTextBlockFormat.getWrapText() et setWrapText(byte) ont été ajoutées**
Les méthodes getWrapText() et setWrapText(/**NullableBool**/byte) ont été ajoutées à l'interface com.aspose.slides.IChartTextBlockFormat.
La modification de cette valeur n’influe que sur les parties de graphique suivantes : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2007/2013).
### **Les méthodes de gestion des marges ont été ajoutées à IChartTextBlockFormat**
Les méthodes getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() et setMarginBottom(double) ont été ajoutées à l'interface com.aspose.slides.IChartTextBlockFormat.
La modification de ces valeurs n’influe que sur les parties de graphique suivantes : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2013 ; dans PowerPoint 2007 il n’y a aucun effet lors du rendu).
### **La méthode ViewProperties.getNotesViewProperties() a été ajoutée**
La propriété com.aspose.slides.ViewProperties.getNotesViewProperties() a été ajoutée. Elle récupère les propriétés communes de la vue associées au mode notes.
### **La méthode ViewProperties.getSlideViewProperties() a été ajoutée**
La méthode com.aspose.slides.ViewProperties.getSlideViewProperties() a été ajoutée. Elle récupère les propriétés communes de la vue associées au mode diapositive.