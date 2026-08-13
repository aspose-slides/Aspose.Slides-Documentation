---
title: Gerenciar rótulos de sensibilidade em apresentações PowerPoint em Java
linktitle: Rótulos de sensibilidade
type: docs
weight: 50
url: /pt/java/sensitivity-labels/
keywords:
- rótulo de sensibilidade
- Microsoft Purview
- Microsoft Information Protection
- metadados MIP
- marcação de conteúdo
- proteção de informação
- governança de documentos
- PowerPoint
- PPTX
- segurança de apresentação
- Java
- Aspose.Slides
description: "Leia, adicione, atualize, remova e migre rótulos de sensibilidade do Microsoft Purview em apresentações PowerPoint PPTX com Aspose.Slides para Java."
---
## **Visão geral**

Os rótulos de sensibilidade do Microsoft Purview ajudam as organizações a classificar e governar documentos. Durante o processamento automatizado de apresentações, um aplicativo pode precisar preservar um rótulo existente, aplicar um rótulo selecionado por uma política, atualizar seu estado ou migrar metadados de rótulo escritos por um fluxo de trabalho mais antigo do Microsoft Information Protection (MIP).

Aspose.Slides expõe metadados de rótulo de sensibilidade modernos através de [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Este método devolve uma [ISensitivityLabelCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabelcollection/) que pode ser inspecionada e modificada antes de a apresentação ser salva como PPTX.

{{% alert color="info" title="Observação" %}}
Os identificadores de rótulos de sensibilidade e as informações de política são definidos pela sua configuração do Microsoft Purview. Valide a disponibilidade de rótulos e os requisitos de política no seu ambiente antes de adicionar ou migrar metadados. Os valores de [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) descrevem as marcações de conteúdo associadas a um rótulo; eles não adicionam, por si só, texto visível ou formas aos slides.
{{% /alert %}}

## **Entender as propriedades do rótulo de sensibilidade**

Cada [ISensitivityLabel](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/) contém os seguintes metadados:

| Métodos | Finalidade |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#getId--) e [ISensitivityLabel.setId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Obtém ou define o identificador do rótulo de sensibilidade na política do Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#getSiteId--) e [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Obtém ou define o site associado à política do rótulo. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#isEnabled--) e [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Obtém ou define se o rótulo está habilitado. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#isRemoved--) e [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Obtém ou define se o rótulo foi removido. Defina o valor como `true` quando o estado de remoção precisar ser mantido nos metadados. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) e [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Obtém ou define se o rótulo foi aplicado automaticamente ou por decisão do usuário. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Obtém os tipos de marcação de conteúdo associados ao rótulo. |

A classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sensitivitylabelassignmenttype/) define como um rótulo foi atribuído:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo padrão ou aplicado automaticamente.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sensitivitylabelassignmenttype/) representa um rótulo aplicado por decisão do usuário, incluindo rótulos aplicados manualmente, recomendados e obrigatórios.

A classe [SensitivityLabelContentType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sensitivitylabelcontenttype/) define a marcação associada a um rótulo:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sensitivitylabelcontenttype/) | O rótulo foi aplicado por padrão ou automaticamente. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sensitivitylabelcontenttype/) | Uma marcação de cabeçalho está associada ao rótulo. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sensitivitylabelcontenttype/) | Uma marcação de rodapé está associada ao rótulo. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sensitivitylabelcontenttype/) | Uma marcação de marca d'água está associada ao rótulo. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sensitivitylabelcontenttype/) | A proteção por criptografia está associada ao rótulo. |

Vários tipos de marcação podem ser associados a um único rótulo.

## **Listar rótulos de sensibilidade existentes**

Leia a coleção de rótulos modernos a partir de [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) e faça a enumeração. O exemplo a seguir lista cada propriedade e marcação de conteúdo armazenadas para cada rótulo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Adicionar um rótulo de sensibilidade com marcação de conteúdo**

Use [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) passando o identificador do rótulo, o identificador do site, o estado habilitado e o método de atribuição. Após o método devolver o novo [ISensitivityLabel](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/), adicione os valores de marcação necessários através da lista devolvida por [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

O exemplo a seguir adiciona um rótulo selecionado manualmente associado a marcações de rodapé e marca d'água e, em seguida, salva o resultado como PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atualizar um rótulo de sensibilidade**

Os valores de [ISensitivityLabel](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/) são leitura/escrita, exceto a lista devolvida por [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--), que é modificada por meio de suas operações de lista. Após localizar o rótulo desejado, você pode atualizar seu identificador, identificador do site, estado habilitado, método de atribuição, estado de remoção e tipos de marcação de conteúdo. Salve a apresentação para persistir as alterações.

O exemplo a seguir atualiza o estado habilitado e o método de atribuição do primeiro rótulo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Marcar um rótulo de sensibilidade como removido**

Para preservar o fato de que um rótulo foi removido, encontre o rótulo e chame [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) com `true`. Isso mantém a entrada do rótulo enquanto registra seu estado removido. Se for necessário excluir a entrada da coleção moderna, use [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); use [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabelcollection/#clear--) para excluir todas as entradas.

O exemplo a seguir marca um rótulo específico como removido e salva a apresentação atualizada:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ler e migrar rótulos de sensibilidade legados do MIP**

Fluxos de trabalho baseados em MIP mais antigos podem armazenar metadados de rótulo de sensibilidade em propriedades de documento personalizadas em vez da coleção de rótulos modernos. Leia esses metadados com [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). O método analisa as propriedades personalizadas legadas e devolve um array de objetos [ISensitivityLabel](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/).

Para migrar os metadados, adicione cada rótulo devolvido à moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabelcollection/) através de [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Como a adição de um identificador de rótulo duplicado gera uma exceção, o exemplo verifica a coleção de destino antes de copiar cada rótulo. Você pode acrescentar validações adicionais para confirmar que cada rótulo legado ainda exista na política atual do Purview.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A migração copia os objetos de rótulo analisados para a coleção moderna. Não é necessário limpar todas as propriedades de documento personalizadas, portanto os metadados de documento não relacionados permanecem intactos. Use [IPresentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveformat/) para gravar os metadados de rótulo modernos em um arquivo PPTX.

## **FAQ**

**Adicionar um tipo de marcação de conteúdo cria um cabeçalho, rodapé ou marca d'água visível nos slides?**

Não. Os valores adicionados por meio da lista devolvida por [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) descrevem as marcações associadas ao rótulo de sensibilidade. Eles não criam texto ou formas visíveis na apresentação. Adicione o conteúdo de slide correspondente separadamente, se o seu fluxo de trabalho precisar renderizar essas marcações.

**Qual a diferença entre marcar um rótulo como removido e excluí‑lo da coleção?**

Chamar [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) com `true` mantém a entrada do rótulo e registra seu estado removido. Chamar [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) exclui a entrada da coleção moderna. Escolha a operação que corresponde aos requisitos de retenção de metadados da sua organização.

**Uma apresentação pode conter metadados legados do MIP e rótulos de sensibilidade modernos ao mesmo tempo?**

Sim. Rótulos legados podem permanecer em propriedades de documento personalizadas enquanto os rótulos modernos ficam disponíveis através de [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Use [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) para ler os metadados legados e migre apenas os rótulos válidos que ainda não estejam presentes na coleção moderna.

**O que acontece quando um rótulo com o mesmo identificador é adicionado mais de uma vez?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) gera uma exceção quando a coleção já contém um rótulo com o mesmo identificador. Verifique os valores existentes devolvidos por [ISensitivityLabel.getId](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isensitivitylabel/#getId--) antes de adicionar ou migrar rótulos.

**Qual formato de saída deve ser usado para preservar os rótulos de sensibilidade atualizados?**

Salve a apresentação como PPTX chamando [IPresentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveformat/), conforme demonstrado nos exemplos acima.