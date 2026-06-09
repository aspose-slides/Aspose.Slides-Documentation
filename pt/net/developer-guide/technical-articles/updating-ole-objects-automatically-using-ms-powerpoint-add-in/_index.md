---
title: Atualizar objetos OLE automaticamente usando um add-in do PowerPoint
type: docs
weight: 10
url: /pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- Objeto OLE
- Atualizar OLE
- Automaticamente
- Add-in
- PowerPoint
- Apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra como atualizar automaticamente gráficos e objetos OLE no PowerPoint com um add-in e o Aspose.Slides for .NET, apresentando código prático e dicas de otimização."
---
## **Introdução**

Uma das perguntas mais frequentes feitas pelos clientes do Aspose.Slides for .NET é como criar ou modificar gráficos editáveis (ou outros objetos OLE) de modo que eles sejam atualizados automaticamente quando a apresentação for aberta. Infelizmente, o PowerPoint não oferece suporte a macros automáticas da mesma forma que o Excel e o Word. As únicas macros disponíveis são `Auto_Open` e `Auto_Close`, e elas só são executadas automaticamente a partir de um add-in. Esta breve dica técnica mostra como alcançar isso.

## **Atualizar Objetos OLE Automaticamente**

Primeiro, existem diversos add-ins gratuitos que adicionam o recurso de macro Auto_Open ao PowerPoint, por exemplo [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) e [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Depois de instalar um desses add-ins, basta acrescentar a macro `Auto_Open()` (ou `OnPresentationOpen()` se estiver usando o Event Generator) à sua apresentação-modelo como mostrado a seguir:

```cs
public void Auto_Open()
{
    // Percorra cada slide na apresentação.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Percorra todas as formas no slide atual.
        foreach (var oShape in oSlide.Shapes)
        {
            // Verifique se a forma é um objeto OLE.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // Objeto OLE encontrado. Obtenha sua referência e então atualize-o.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Agora, saia do programa servidor OLE.
                // Isso libera memória e evita problemas.
                // Além disso, defina oObject como Nothing para liberar o objeto.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Quaisquer alterações feitas nos objetos OLE com o Aspose.Slides for .NET serão atualizadas automaticamente quando o PowerPoint abrir a apresentação. Se você tiver muitos objetos OLE e não quiser atualizá-los todos, basta acrescentar uma tag personalizada nas formas que precisam ser processadas e verificá‑la na macro.