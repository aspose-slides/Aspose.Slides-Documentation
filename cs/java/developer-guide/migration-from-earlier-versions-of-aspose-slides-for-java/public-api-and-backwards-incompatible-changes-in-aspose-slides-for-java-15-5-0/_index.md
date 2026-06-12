---
title: Veřejné API a nekompatibilní změny v Aspose.Slides pro Java 15.5.0
linktitle: Aspose.Slides pro Java 15.5.0
type: docs
weight: 130
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a zásadní změny v Aspose.Slides pro Java a snadno migrujte svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) třídy, metody, vlastnosti atd., všechna nová omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) zavedené v API Aspose.Slides pro Java 15.5.0.
{{% /alert %}} 
## **Změny veřejného API**
### **Byla přidána třída CommonSlideViewProperties a rozhraní ICommonSlideViewProperties**
Třída com.aspose.slides.CommonSlideViewProperties (a její rozhraní com.aspose.slides.ICommonSlideViewProperties) představuje společné vlastnosti zobrazení snímku (aktuálně možnosti měřítka zobrazení).
### **Metody IAxis.getLabelOffset() a setLabelOffset(int) byly přidány**
Metody IAxis.getLabelOffset() a setLabelOffset(int) umožňují získat a určit vzdálenost popisků od osy. Používá se pro kategoriální nebo datumovou osu.
### **Metody IChartTextBlockFormat.getAutofitType() a setAutofitType(byte) byly přidány**
Metody getAutofitType() a setAutofitType(/**TextAutofitType**/byte) byly přidány do rozhraní com.aspose.slides.IChartTextBlockFormat.
Změna této hodnoty může mít vliv pouze na následující části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2013; v PowerPoint 2007 nemá žádný vliv na vykreslování).
### **Metody IChartTextBlockFormat.getWrapText() a setWrapText(byte) byly přidány**
Metody getWrapText() a setWrapText(/**NullableBool**/byte) byly přidány do rozhraní com.aspose.slides.IChartTextBlockFormat.
Změna této hodnoty může mít vliv pouze na následující části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2007/2013).
### **Metody pro správu okrajů byly do IChartTextBlockFormat přidány**
Metody getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() a setMarginBottom(double) byly přidány do rozhraní com.aspose.slides.IChartTextBlockFormat.
Změna těchto hodnot může mít vliv pouze na následující části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2013; v PowerPoint 2007 nemá žádný vliv na vykreslování).
### **Metoda ViewProperties.getNotesViewProperties() byla přidána**
Vlastnost com.aspose.slides.ViewProperties.getNotesViewProperties() byla přidána. Vrací společné vlastnosti zobrazení spojené s režimem náhledu poznámek.
### **Metoda ViewProperties.getSlideViewProperties() byla přidána**
Metoda com.aspose.slides.ViewProperties.getSlideViewProperties() byla přadded. Vrací společné vlastnosti zobrazení spojené s režimem zobrazení snímku.