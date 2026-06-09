---
title: Extrair objetos Flash de apresentações no Android
linktitle: Flash
type: docs
weight: 10
url: /pt/androidjava/flash/
keywords:
- extrair flash
- objeto flash
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a extrair objetos Flash de slides PowerPoint e OpenDocument em Java com Aspose.Slides para Android, com exemplos de código completos e boas práticas."
---
## **Visão geral**

Este artigo explica como extrair objetos Flash de apresentações usando o Aspose.Slides. Ele mostra como localizar um controle Flash pelo nome na coleção de controles de um slide e trabalhar com os dados incorporados do objeto SWF.

## **Extrair objetos Flash de apresentações**

O Aspose.Slides para Android via Java oferece um recurso para extrair objetos flash de uma apresentação. Você pode acessar o controle flash pelo nome e extraí‑lo da apresentação, incluindo o armazenamento dos dados do objeto SWF.

```java
// Instanciar a classe Presentation que representa o PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas frequentes**

**Quais formatos de apresentação são suportados ao extrair conteúdo Flash?**

[Aspose.Slides suporta](/slides/pt/androidjava/supported-file-formats/) os principais formatos do PowerPoint, como PPT e PPTX, pois pode carregar esses contêineres e acessar seus controles, incluindo elementos ActiveX relacionados ao Flash.

**Posso converter uma apresentação com Flash para HTML5 e preservar a interatividade do Flash?**

Não. O Aspose.Slides não executa conteúdo SWF nem converte sua interatividade. Embora a exportação para [HTML](/slides/pt/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/pt/androidjava/export-to-html5/) seja suportada, o Flash não será reproduzido em navegadores modernos devido ao fim do suporte. O caminho recomendado é substituir o Flash por alternativas, como vídeo ou animações HTML5, antes da exportação.

**Do ponto de vista de segurança, o Aspose.Slides executa arquivos SWF ao ler uma apresentação?**

Não. O Aspose.Slides trata o Flash como dados binários incorporados ao arquivo e não executa conteúdo SWF durante o processamento.

**Como devo lidar com apresentações que incluem Flash junto com outros arquivos incorporados via OLE?**

O Aspose.Slides suporta [extraindo objetos OLE incorporados](/slides/pt/androidjava/manage-ole/), permitindo processar todo o conteúdo incorporado relacionado em uma única passagem, manipulando controles Flash e outros documentos incorporados via OLE simultaneamente.