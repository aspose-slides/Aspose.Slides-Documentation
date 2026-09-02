---
title: Gerenciar rótulos de sensibilidade em apresentações PowerPoint no .NET
linktitle: Rótulos de sensibilidade
type: docs
weight: 50
url: /pt/net/sensitivity-labels/
keywords:
- rótulo de sensibilidade
- Microsoft Purview
- Microsoft Information Protection
- metadados MIP
- marcação de conteúdo
- proteção de informações
- governança de documentos
- PowerPoint
- PPTX
- segurança de apresentações
- .NET
- C#
- Aspose.Slides
description: "Leia, adicione, atualize, remova e migre rótulos de sensibilidade do Microsoft Purview em apresentações PowerPoint PPTX com Aspose.Slides para .NET."
---
## **Visão geral**

Os rótulos de sensibilidade do Microsoft Purview ajudam as organizações a classificar e governar documentos. Durante o processamento automatizado de apresentações, um aplicativo pode precisar preservar um rótulo existente, aplicar um rótulo selecionado por uma política, atualizar seu estado ou migrar os metadados de rótulo gravados por um fluxo de trabalho mais antigo do Microsoft Information Protection (MIP).

Aspose.Slides expõe os metadados modernos de rótulos de sensibilidade através de [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sensitivitylabels/). Esta propriedade retorna uma [ISensitivityLabelCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/) que pode ser inspecionada e modificada antes que a apresentação seja salva como PPTX.

{{% alert color="primary" title="Note" %}}
Os identificadores de rótulo de sensibilidade e as informações de política são definidos pela sua configuração do Microsoft Purview. Valide a disponibilidade dos rótulos e os requisitos de política no seu ambiente antes de adicionar ou migrar metadados. Os valores de [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/contentmarktypes/) descrevem as marcações de conteúdo associadas a um rótulo; eles não adicionam, por si só, texto ou formas visíveis aos slides.
{{% /alert %}}

## **Entender as propriedades do rótulo de sensibilidade**

Cada [ISensitivityLabel](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/) contém os seguintes metadados:

| Propriedade | Finalidade |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/id/) | Identifica o rótulo de sensibilidade na política do Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/siteid/) | Identifica o site associado à política do rótulo. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/isenabled/) | Indica se o rótulo está habilitado. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/isremoved/) | Indica que o rótulo foi removido. Defina esta propriedade como `true` quando o estado de remoção precisar ser mantido nos metadados. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Especifica se o rótulo foi aplicado automaticamente ou por decisão do usuário. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Lista os tipos de marcações de conteúdo associados ao rótulo. |

A enumeração [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelassignmenttype/) descreve como um rótulo foi atribuído:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo padrão ou aplicado automaticamente.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo aplicado por decisão do usuário, incluindo rótulos aplicados manualmente, recomendados e obrigatórios.

A enumeração [SensitivityLabelContentType](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) identifica a marcação associada a um rótulo:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) | O rótulo foi aplicado por padrão ou automaticamente. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) | Marca de conteúdo de cabeçalho está associada ao rótulo. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) | Marca de conteúdo de rodapé está associada ao rótulo. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) | Marca de conteúdo de marca d'água está associada ao rótulo. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/pt/net/aspose.slides/sensitivitylabelcontenttype/) | Proteção de criptografia está associada ao rótulo. |

Vários tipos de marcação podem ser associados a um rótulo.

## **Listar rótulos de sensibilidade existentes**

Leia a coleção moderna de rótulos de [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sensitivitylabels/) e enumere-a. O exemplo a seguir lista todas as propriedades e marcações de conteúdo armazenadas para cada rótulo:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Adicionar um rótulo de sensibilidade com marcação de conteúdo**

Use [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/add/) com o identificador do rótulo, identificador do site, estado habilitado e método de atribuição. Após o método retornar o novo [ISensitivityLabel](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/), adicione os valores de marcação necessários através de [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/contentmarktypes/).

O exemplo a seguir adiciona um rótulo selecionado manualmente associado às marcações de rodapé e marca d'água, e então salva o resultado como PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Atualizar um rótulo de sensibilidade**

As propriedades de [ISensitivityLabel](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/) são leitura/gravação, exceto que a coleção retornada por [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/contentmarktypes/) é modificada por suas operações de lista. Após localizar o rótulo necessário, você pode atualizar seu identificador, identificador do site, estado habilitado, método de atribuição, estado de remoção e tipos de marcação de conteúdo. Salve a apresentação para persistir as alterações.

O exemplo a seguir atualiza o estado habilitado e o método de atribuição do primeiro rótulo:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Marcar um rótulo de sensibilidade como removido**

Para preservar o fato de que um rótulo foi removido, encontre o rótulo e defina [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/isremoved/) como `true`. Isso mantém a entrada do rótulo enquanto registra seu estado removido. Caso precise excluir uma entrada da coleção moderna, use [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/removeat/); use [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/clear/) para excluir todas as entradas.

O exemplo a seguir marca um rótulo específico como removido e salva a apresentação atualizada:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Ler e migrar rótulos de sensibilidade legados do MIP**

Fluxos de trabalho mais antigos baseados em MIP podem armazenar metadados de rótulo de sensibilidade em propriedades de documento personalizadas em vez da coleção moderna de rótulos. Leia esses metadados com [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/getsensitivitylabels/). O método analisa as propriedades personalizadas legadas e retorna um array de objetos [ISensitivityLabel](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/).

Para migrar os metadados, adicione cada rótulo retornado à moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/) através de [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/add/). Como a adição de um identificador de rótulo duplicado gera uma exceção, o exemplo verifica a coleção de destino antes de copiar cada rótulo. Você pode adicionar validações adicionais para confirmar que cada rótulo legado ainda existe na política atual do Purview.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

A migração copia os objetos de rótulo analisados para a coleção moderna. Não é necessário limpar todas as propriedades de documento personalizadas, portanto os metadados de documento não relacionados permanecem intactos. Use [IPresentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/save/) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/) para gravar os metadados modernos de rótulo em um arquivo PPTX.

## **Perguntas frequentes**

**Adicionar um tipo de marcação de conteúdo cria um cabeçalho, rodapé ou marca d'água visível nos slides?**

Não. Os valores adicionados através de [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/contentmarktypes/) descrevem as marcações associadas ao rótulo de sensibilidade. Eles não criam texto ou formas visíveis na apresentação. Adicione o conteúdo de slide correspondente separadamente se o seu fluxo de trabalho precisar renderizar essas marcações.

**Qual é a diferença entre marcar um rótulo como removido e excluí-lo da coleção?**

Definir [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/isremoved/) como `true` mantém a entrada do rótulo e registra seu estado removido. Chamar [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/removeat/) exclui a entrada da coleção moderna. Escolha a operação que corresponde aos requisitos de retenção de metadados da sua organização.

**Uma apresentação pode conter tanto metadados legados do MIP quanto rótulos de sensibilidade modernos?**

Sim. Rótulos legados podem permanecer nas propriedades de documento personalizadas enquanto os rótulos modernos estão disponíveis através de [Presentation.SensitivityLabels](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/sensitivitylabels/). Use [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/getsensitivitylabels/) para ler os metadados legados e migrar apenas os rótulos válidos que ainda não estejam presentes na coleção moderna.

**O que acontece quando um rótulo com o mesmo identificador é adicionado mais de uma vez?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabelcollection/add/) lança uma `ArgumentException` quando a coleção já contém um rótulo com o mesmo identificador. Verifique os valores existentes de [ISensitivityLabel.Id](https://reference.aspose.com/slides/pt/net/aspose.slides/isensitivitylabel/id/) antes de adicionar ou migrar rótulos.

**Qual formato de saída deve ser usado para preservar os rótulos de sensibilidade atualizados?**

Salve a apresentação como PPTX chamando [IPresentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/save/) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/), como mostrado nos exemplos acima.