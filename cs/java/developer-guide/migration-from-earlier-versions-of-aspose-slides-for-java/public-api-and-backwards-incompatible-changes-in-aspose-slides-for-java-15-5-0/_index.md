---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 15.5.0
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
description: "Prohlédněte si aktualizace veřejného API a nepřetržité změny v Aspose.Slides pro Java, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 
Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) třídy, metody, vlastnosti a podobně, všechny nové omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) zavedené v rozhraní Aspose.Slides pro Java 15.5.0 API.
{{% /alert %}} 
## **Změny veřejného API**
### **Byla přidána třída CommonSlideViewProperties a rozhraní ICommonSlideViewProperties**
Třída com.aspose.slides.CommonSlideViewProperties (a její rozhraní com.aspose.slides.ICommonSlideViewProperties) představuje obecné vlastnosti zobrazení snímků (aktuálně možnosti měřítka zobrazení).
### **Metody IAxis.getLabelOffset() a setLabelOffset(int) byly přidány**
Metody IAxis.getLabelOffset() a setLabelOffset(int) umožňují získat a zadat vzdálenost popisků od osy. Platí pro kategoriální nebo datovou osu.
### **Metody IChartTextBlockFormat.getAutofitType() a setAutofitType(byte) byly přidány**
Metody getAutofitType() a setAutofitType(/**TextAutofitType**/byte) byly přidány do rozhraní com.aspose.slides.IChartTextBlockFormat.
Změna této hodnoty může mít vliv pouze na tyto části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2013; v PowerPoint 2007 nemá žádný vliv na vykreslení).
### **Metody IChartTextBlockFormat.getWrapText() a setWrapText(byte) byly přidány**
Metody getWrapText() a setWrapText(/**NullableBool**/byte) byly přidány do rozhraní com.aspose.slides.IChartTextBlockFormat.
Změna této hodnoty může mít vliv pouze na tyto části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2007/2013).
### **Metody pro správu okrajů byly přidány do IChartTextBlockFormat**
Metody getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() a setMarginBottom(double) byly přidány do rozhraní com.aspose.slides.IChartTextBlockFormat.
Změna těchto hodnot může mít vliv pouze na tyto části grafu: DataLabel a DataLabelFormat (plná podpora v PowerPoint 2013; v PowerPoint 2007 nemá žádný vliv na vykreslení).
### **Metoda ViewProperties.getNotesViewProperties() byla přidána**
Vlastnost com.aspose.slides.ViewProperties.getNotesViewProperties() byla přidána. Vrací obecné vlastnosti zobrazení související s režimem zobrazení poznámek.
### **Metoda ViewProperties.getSlideViewProperties() byla přidána**
Metoda com.aspose.slides.ViewProperties.getSlideViewProperties() byla přidána. Vrací obecné vlastnosti zobrazení související s režimem zobrazení snímků.