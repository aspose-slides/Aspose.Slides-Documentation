---
title: API public et changements incompatibles en arrière dans Aspose.Slides pour Java 15.5.0
type: docs
weight: 130
url: /fr/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/fr/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) de classes, méthodes, propriétés, etc., toute nouvelle restriction et d'autres [changements](/slides/fr/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) introduits avec l'API Aspose.Slides pour Java 15.5.0.

{{% /alert %}} 
## **Changements de l'API publique**
### **La classe CommonSlideViewProperties et l'interface ICommonSlideViewProperties ont été ajoutées**
La classe com.aspose.slides.CommonSlideViewProperties (et son interface com.aspose.slides.ICommonSlideViewProperties) représente les propriétés de vue de diapositive communes (actuellement les options d'échelle de vue).
### **Les méthodes IAxis.getLabelOffset(), setLabelOffset(int) ont été ajoutées**
Les méthodes IAxis.getLabelOffset(), setLabelOffset(int) permettent d'obtenir et de spécifier la distance des étiquettes par rapport à l'axe. Appliqué à l'axe des catégories ou des dates.
### **Les méthodes IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) ont été ajoutées**
Les méthodes getAutofitType(), setAutofitType(/**TextAutofitType**/byte) ont été ajoutées à l'interface com.aspose.slides.IChartTextBlockFormat.
Le changement de cette valeur peut avoir une certaine influence uniquement pour ces parties de graphique : DataLabel et DataLabelFormat (support complet dans PowerPoint 2013 ; dans PowerPoint 2007, il n'y a pas d'effet sur le rendu).
### **Les méthodes IChartTextBlockFormat.getWrapText(), setWrapText(byte) ont été ajoutées**
Les méthodes getWrapText(), setWrapText(/**NullableBool**/byte) ont été ajoutées à l'interface com.aspose.slides.IChartTextBlockFormat.
Le changement de cette valeur peut avoir une certaine influence uniquement pour ces parties de graphique : DataLabel et DataLabelFormat (support complet dans PowerPoint 2007/2013).
### **Les méthodes pour gérer les marges ont été ajoutées à IChartTextBlockFormat**
Les méthodes getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() et setMarginBottom(double) ont été ajoutées à l'interface com.aspose.slides.IChartTextBlockFormat.
Le changement de ces valeurs peut avoir une certaine influence uniquement pour ces parties de graphique : DataLabel et DataLabelFormat (support complet dans PowerPoint 2013 ; dans PowerPoint 2007, il n'y a pas d'effet sur le rendu).
### **La méthode ViewProperties.getNotesViewProperties() a été ajoutée**
La propriété com.aspose.slides.ViewProperties.getNotesViewProperties() a été ajoutée. Elle obtient les propriétés de vue communes associées au mode de vue des notes.
### **La méthode ViewProperties.getSlideViewProperties() a été ajoutée**
La méthode com.aspose.slides.ViewProperties.getSlideViewProperties() a été ajoutée. Elle obtient les propriétés de vue communes associées au mode de vue des diapositives.