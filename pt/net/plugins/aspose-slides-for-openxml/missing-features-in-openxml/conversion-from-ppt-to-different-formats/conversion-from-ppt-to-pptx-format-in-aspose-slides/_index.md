---
title: Conversão de PPT para formato PPTX em Aspose.Slides
type: docs
weight: 10
url: /pt/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** para .NET agora permite que os desenvolvedores acessem o PPT usando uma instância da classe Presentation e o convertam para o formato PPTX correspondente. Atualmente, suporta conversão parcial de PPT para PPTX. Para mais detalhes sobre quais recursos são suportados e não suportados na conversão de PPT para PPTX, consulte este link de documentação.

**Aspose.Slides** para .NET oferece a classe Presentation que representa um arquivo de apresentação PPTX. A classe Presentation agora também pode acessar PPT através de Presentation quando o objeto é instanciado.

``` csharp

 //Instanciar um objeto Presentation que representa um arquivo PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Salvar a apresentação PPTX no formato PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Baixar Código de Exemplo**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)