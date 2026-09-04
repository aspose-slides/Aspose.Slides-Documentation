---
title: Licenciamento
type: docs
weight: 80
url: /pt/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- arquivo de licença
- licença temporária
- licenciamento por consumo
- limitações de avaliação
description: "Aplique uma licença baseada em arquivo, em bytes ou por consumo no Aspose.Slides for Python via Java e remova as limitações de avaliação de suas aplicações."
---
## **Visão geral**

Aspose.Slides for Python via Java pode ser executado no modo de avaliação ou com uma licença. Este artigo explica como aplicar uma licença a partir de um arquivo ou bytes e como configurar o licenciamento por consumo.

Para opções de compra, veja [Informações de Preços](https://purchase.aspose.com/pricing/slides/pt/family). Para perguntas gerais sobre licenciamento e compra, veja [Políticas de Compra e FAQ](https://purchase.aspose.com/policies).

Para limitações de avaliação e como solicitar uma licença temporária, veja [Avaliar Aspose.Slides](/slides/pt/python-java/evaluate-aspose-slides/). Aplique uma licença temporária da mesma forma que um arquivo de licença adquirido.

## **Sobre a Licença**

Um arquivo de licença contém informações como o nome do produto, o número de desenvolvedores licenciados e a data de expiração da assinatura. O arquivo é um XML assinado digitalmente.

{{% alert color="warning" title="Aviso" %}}
Não edite o arquivo de licença. Mesmo uma quebra de linha extra pode invalidar sua assinatura digital.
{{% /alert %}}

Aplicar a licença uma vez por aplicação ou processo, antes de criar apresentações ou executar outras operações do Aspose.Slides. Para um arquivo de licença, use a classe [License](https://reference.aspose.com/slides/pt/python-java/aspose.slides/license/). O licenciamento por consumo usa um par de chaves pública e privada em vez de um arquivo de licença.

## **Aplicar uma Licença**

Os exemplos a seguir assumem que o Aspose.Slides for Python via Java e seus pré-requisitos estão instalados. Cada exemplo é um script autônomo que inicia a JVM, importa a API e aplica uma licença. Em sua aplicação, execute as operações de apresentação após aplicar a licença e desligue a JVM somente depois que todo o trabalho do Aspose.Slides estiver concluído.

### **Aplicar uma Licença a partir de um Arquivo**

Passe o caminho do arquivo de licença para [License.setLicense](https://reference.aspose.com/slides/pt/python-java/aspose.slides/license/#setLicense). Substitua `Aspose.Slides.lic` pelo caminho do seu arquivo de licença.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Execute as operações de apresentação aqui, antes de encerrar a JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Use o nome exato do arquivo, incluindo sua extensão. Por exemplo, se o arquivo for chamado `Aspose.Slides.lic.xml`, inclua `.xml` no caminho. Um caminho absoluto evita ambiguidades sobre o diretório de trabalho da aplicação.

O exemplo usa [License.isLicensed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/license/#isLicensed) para verificar se a licença foi aplicada.

### **Aplicar uma Licença a partir de Bytes**

Use [License.setLicenseFromBytes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/license/#setLicenseFromBytes) quando a licença estiver disponível como bytes Python. O exemplo a seguir lê o arquivo em modo binário e o fecha antes de aplicar a licença.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Execute as operações de apresentação aqui, antes de encerrar a JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Mantenha os bytes originais inalterados. Não decodifique, reformate ou modifique o conteúdo da licença antes de aplicá‑la.

## **Aplicar uma Licença por Consumo**

O licenciamento por consumo cobra de acordo com o uso da API. Após obter uma licença por consumo, aplique suas chaves pública e privada com [Metered.setMeteredKey](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/#setMeteredKey). Inicialize o objeto [Metered](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/) e aplique as chaves uma vez na inicialização da aplicação.

O exemplo a seguir lê as chaves das variáveis de ambiente `ASPOSE_METERED_PUBLIC_KEY` e `ASPOSE_METERED_PRIVATE_KEY`. Defina ambas as variáveis antes de executar o script.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Execute as operações de apresentação aqui, antes de encerrar a JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Nota" %}}
O licenciamento por consumo requer uma conexão à Internet para validar as chaves e relatar o uso. Mantenha a chave privada fora do código‑fonte e dos logs. Consulte o [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) para detalhes de conectividade e cobrança.
{{% /alert %}}

## **Perguntas Frequentes**

**Preciso instalar um pacote diferente após comprar uma licença?**

Não. Aplique a licença ao mesmo pacote que você usou na avaliação.

**Devo aplicar uma licença para cada apresentação?**

Não. Aplique‑a uma vez durante a inicialização da aplicação, antes de criar ou carregar apresentações.

**Posso renomear o arquivo de licença?**

Sim. Use o nome exato do novo arquivo no seu código e mantenha o conteúdo do arquivo inalterado.

**Posso usar uma licença temporária com o exemplo baseado em bytes?**

Sim. Leia o arquivo de licença temporária como bytes e aplique‑a da mesma forma que uma licença adquirida.