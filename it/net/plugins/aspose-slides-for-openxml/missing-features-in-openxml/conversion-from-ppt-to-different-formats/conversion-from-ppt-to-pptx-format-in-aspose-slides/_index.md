---
title: Conversione dal formato PPT al formato PPTX in Aspose.Slides
type: docs
weight: 10
url: /it/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** per .NET ora consente agli sviluppatori di accedere al PPT usando un'istanza della classe Presentation e di convertirlo nel relativo formato PPTX. Attualmente supporta la conversione parziale da PPT a PPTX. Per ulteriori dettagli su quali funzionalità sono supportate e non supportate nella conversione da PPT a PPTX, si prega di consultare questo link alla documentazione.

**Aspose.Slides** per .NET offre la classe Presentation che rappresenta un file di presentazione PPTX. La classe Presentation può ora accedere anche ai file PPT tramite Presentation quando l'oggetto viene istanziato.

``` csharp

 //Instanzia un oggetto Presentation che rappresenta un file PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Salvataggio della presentazione PPTX nel formato PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Scarica Codice di Esempio**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)