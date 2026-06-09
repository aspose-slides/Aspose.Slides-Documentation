---
title: Atualizar objetos OLE automaticamente usando um add-in do PowerPoint
type: docs
weight: 10
url: /pt/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- objeto OLE
- atualizar OLE
- automaticamente
- add-in
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Descubra como atualizar automaticamente gráficos e objetos OLE no PowerPoint com um add-in e Aspose.Slides para Java, apresentando código prático e dicas de otimização."
---
## **Introdução**

Uma das perguntas mais frequentes feitas pelos clientes do Aspose.Slides for Java é como criar ou modificar gráficos editáveis (ou outros objetos OLE) para que eles sejam atualizados automaticamente quando a apresentação for aberta. Infelizmente, o PowerPoint não oferece suporte a macros automáticas da mesma forma que o Excel e o Word. As únicas macros disponíveis são `Auto_Open` e `Auto_Close`, e elas só são executadas automaticamente a partir de um add-in. Esta breve dica técnica mostra como conseguir isso.

## **Atualizar objetos OLE automaticamente**

Primeiro, vários complementos gratuitos estão disponíveis que adicionam a funcionalidade de macro Auto_Open ao PowerPoint, por exemplo [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) e [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Após instalar um desses complementos, basta adicionar a macro `Auto_Open()` (ou `OnPresentationOpen()` se você estiver usando o Event Generator) à sua apresentação modelo, conforme mostrado abaixo:

```java
// Percorra cada slide na apresentação.
for (var oSlide : ActivePresentation.Slides) {
    // Percorra todas as formas no slide atual.
    for (var oShape : oSlide.Shapes) {
        // Verifique se a forma é um objeto OLE.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Encontrado um objeto OLE. Obtenha sua referência de objeto e então atualize-o.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Agora, saia do programa servidor OLE.
            // Isso libera memória e evita quaisquer problemas.
            // Também, defina oObject como Nothing para liberar o objeto.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Quaisquer alterações feitas em objetos OLE com Aspose.Slides for Java serão atualizadas automaticamente quando o PowerPoint abrir a apresentação. Se você tem muitos objetos OLE e não deseja atualizá-los todos, basta adicionar uma tag personalizada às formas que precisam ser processadas e verificá-la na macro.