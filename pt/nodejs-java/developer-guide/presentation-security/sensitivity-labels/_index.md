---
title: Gerenciar rótulos de sensibilidade em apresentações PowerPoint em JavaScript
linktitle: Rótulos de Sensibilidade
type: docs
weight: 50
url: /pt/nodejs-java/sensitivity-labels/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Leia, adicione, atualize, remova e migre rótulos de sensibilidade do Microsoft Purview em apresentações PowerPoint PPTX com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Os rótulos de sensibilidade do Microsoft Purview ajudam as organizações a classificar e governar documentos. Durante o processamento automático de apresentações, um aplicativo pode precisar preservar um rótulo existente, aplicar um rótulo selecionado por uma política, atualizar seu estado ou migrar metadados de rótulo gravados por um fluxo de trabalho mais antigo do Microsoft Information Protection (MIP).

Aspose.Slides for Node.js via Java expõe metadados modernos de rótulos de sensibilidade através de [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Esse método retorna um [SensitivityLabelCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcollection/) que pode ser inspeccionado e modificado antes que a apresentação seja salva como PPTX.

{{% alert color="primary" title="Nota" %}}

Os identificadores de rótulo de sensibilidade e as informações de política são definidos pela sua configuração do Microsoft Purview. Valide a disponibilidade de rótulos e os requisitos de política no seu ambiente antes de adicionar ou migrar metadados. Os valores de [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) descrevem as marcações de conteúdo associadas a um rótulo; eles não adicionam texto ou formas visíveis aos slides por si só.

{{% /alert %}}

## **Compreender as propriedades do rótulo de sensibilidade**

Cada [SensitivityLabel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/) contém os seguintes metadados:

| Métodos | Objetivo |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#getId) e [SensitivityLabel.setId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Obter ou definir o identificador do rótulo de sensibilidade na política do Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) e [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Obter ou definir o site associado à política do rótulo. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) e [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Obter ou definir se o rótulo está habilitado. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) e [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Obter ou definir se o rótulo foi removido. Defina o valor como `true` quando o estado de remoção precisar ser mantido nos metadados. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) e [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Obter ou definir se o rótulo foi aplicado automaticamente ou por decisão do usuário. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Obter os tipos de marcação de conteúdo associados ao rótulo. |

A classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) define como um rótulo foi atribuído:

- `SensitivityLabelAssignmentType.Standard` representa um rótulo padrão ou aplicado automaticamente.
- `SensitivityLabelAssignmentType.Privileged` representa um rótulo aplicado por decisão do usuário, incluindo rótulos aplicados manualmente, recomendados e obrigatórios.

A classe [SensitivityLabelContentType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) define a marcação associada a um rótulo:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | O rótulo foi aplicado por padrão ou automaticamente. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo de cabeçalho está associada ao rótulo. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo de rodapé está associada ao rótulo. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | A marcação de conteúdo de marca d'água está associada ao rótulo. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | A proteção de criptografia está associada ao rótulo. |

Vários tipos de marcação podem ser associados a um rótulo.

## **Listar rótulos de sensibilidade existentes**

Leia a coleção moderna de rótulos de [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) e enumere-a. O exemplo a seguir lista todas as propriedades e marcações de conteúdo armazenadas para cada rótulo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Adicionar um rótulo de sensibilidade com marcação de conteúdo**

Use [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) com o identificador do rótulo, o identificador do site, o estado habilitado e o método de atribuição. Após o método retornar o novo [SensitivityLabel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/), adicione os valores de marcação necessários através da lista retornada por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

O exemplo a seguir adiciona um rótulo selecionado manualmente associado a marcações de rodapé e marca d'água e, em seguida, salva o resultado como PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atualizar um rótulo de sensibilidade**

Os valores de [SensitivityLabel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/) são leitura/gravação, exceto a lista retornada por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), que é modificada por suas operações de lista. Após localizar o rótulo necessário, você pode atualizar seu identificador, identificador do site, estado habilitado, método de atribuição, estado de remoção e tipos de marcação de conteúdo. Salve a apresentação para persistir as alterações.

O exemplo a seguir atualiza o estado habilitado e o método de atribuição do primeiro rótulo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Marcar um rótulo de sensibilidade como removido**

Para preservar o fato de que um rótulo foi removido, encontre o rótulo e chame [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) com `true`. Isso mantém a entrada do rótulo enquanto registra seu estado removido. Se precisar excluir uma entrada da coleção moderna, use [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); use [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) para excluir todas as entradas.

O exemplo a seguir marca um rótulo específico como removido e salva a apresentação atualizada:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ler e migrar rótulos de sensibilidade legados do MIP**

Fluxos de trabalho baseados em MIP mais antigos podem armazenar metadados de rótulo de sensibilidade em propriedades personalizadas do documento em vez da coleção moderna de rótulos. Leia esses metadados com [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). O método analisa as propriedades personalizadas legadas e retorna um array de objetos [SensitivityLabel](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/).

Para migrar os metadados, adicione cada rótulo retornado à moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcollection/) por meio de [SensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Como a adição de um identificador de rótulo duplicado gera uma exceção, o exemplo verifica a coleção de destino antes de copiar cada rótulo. Você pode acrescentar validações adicionais para confirmar que cada rótulo legado ainda existe na política atual do Purview.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A migração copia os objetos de rótulo analisados para a coleção moderna. Não é necessário limpar todas as propriedades personalizadas do documento, portanto, os metadados não relacionados permanecem intactos. Use [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/) para gravar os metadados modernos de rótulo em um arquivo PPTX.

## **FAQ**

**Adicionar um tipo de marcação de conteúdo cria um cabeçalho, rodapé ou marca d'água visível nos slides?**

Não. Os valores adicionados através da lista retornada por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) descrevem as marcações associadas ao rótulo de sensibilidade. Eles não criam texto ou formas visíveis na apresentação. Adicione o conteúdo correspondente dos slides separadamente se o seu fluxo de trabalho precisar renderizar essas marcações.

**Qual é a diferença entre marcar um rótulo como removido e excluí‑lo da coleção?**

Chamar [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) com `true` mantém a entrada do rótulo e registra seu estado removido. Chamar [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) exclui a entrada da coleção moderna. Escolha a operação que corresponde aos requisitos de retenção de metadados da sua organização.

**Uma apresentação pode conter tanto metadados legados do MIP quanto rótulos de sensibilidade modernos?**

Sim. Rótulos legados podem permanecer nas propriedades personalizadas do documento enquanto os rótulos modernos ficam disponíveis através de [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Use [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) para ler os metadados legados e migrar apenas os rótulos válidos que ainda não estejam presentes na coleção moderna.

**O que acontece quando um rótulo com o mesmo identificador é adicionado mais de uma vez?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) gera uma exceção quando a coleção já contém um rótulo com o mesmo identificador. Verifique os valores existentes retornados por [SensitivityLabel.getId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sensitivitylabel/#getId) antes de adicionar ou migrar rótulos.

**Qual formato de saída deve ser usado para preservar os rótulos de sensibilidade atualizados?**

Salve a apresentação como PPTX chamando [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/), conforme mostrado nos exemplos acima.