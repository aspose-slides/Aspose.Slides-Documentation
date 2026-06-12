---
title: Konverze formátu PPT na PPTX v Aspose.Slides
type: docs
weight: 10
url: /cs/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** pro .NET nyní usnadňuje vývojářům přístup k PPT pomocí instance třídy Presentation a její převod do příslušného formátu PPTX. V současnosti podporuje částečný převod PPT na PPTX. Pro podrobnější informace o tom, které funkce jsou při převodu PPT na PPTX podporovány a které nejsou, přejděte na tento odkaz na dokumentaci.

**Aspose.Slides** pro .NET nabízí třídu Presentation, která představuje soubor prezentace PPTX. Třída Presentation nyní může také přistupovat k PPT prostřednictvím Presentation při vytvoření objektu.

``` csharp

 //Vytvořte objekt Presentation, který představuje soubor PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Ukládání prezentace PPTX do formátu PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Stáhnout ukázkový kód**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)