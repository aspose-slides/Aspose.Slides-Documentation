---
title: API Pública e Mudanças Incompatíveis com Versões Anteriores no Aspose.Slides para .NET 14.2.0
linktitle: Aspose.Slides para .NET 14.2.0
type: docs
weight: 40
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
## **API Pública e Mudanças Incompatíveis com Versões Anteriores**
{{% alert color="primary" %}} 
Fizemos algumas alterações na API do Aspose.Slides para .NET 14.2.0. Algumas propriedades e métodos foram removidos e alguns foram movidos para outro namespace.
{{% /alert %}} 
### **Métodos Aspose.Slides.IPresentation.Write(…) Removidos**
Esses métodos gravavam objetos Presentation apenas em arquivos no formato PPTX. Na nova API, a classe Presentation serve para trabalhar com todos os formatos. É possível usar os métodos Presentation.Save(…) para salvar os objetos Presentation em todos os formatos suportados.
### **Classes Relacionadas a Estilos de Tema Movidas para o Namespace Aspose.Slides.Theme**
As classes a seguir foram movidas do namespace Aspose.Slides para o namespace Aspose.Slides.Theme.

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Alterações a partir do Aspose.Slides para .NET 8.X.0**
Recursos do Aspose.Slides para .NET 8.4 foram adicionados ao Aspose.Slides para .NET 14.2.0