---
title: Compatibilidade com PyInstaller e cx_Freeze
linktitle: Compatibilidade com PyInstaller
type: docs
weight: 122
url: /pt/python-net/compatibility-with-pyinstaller/
keywords:
- compatibilidade
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Empacote Aspose.Slides for Python via .NET com PyInstaller. Siga este guia para agrupar, configurar e solucionar problemas da sua aplicação em um executável autônomo."
---
## **Introdução**

Aspose.Slides for Python via .NET extensions são extensões C padrão do Python, de modo que podem ser congeladas como dependências do programa com ferramentas como PyInstaller e cx_Freeze (ou semelhantes). Isso permite criar arquivos executáveis a partir dos seus scripts Python. Essas ferramentas são chamadas de “congeladores” porque agrupam seu código e suas dependências em um único arquivo distribuível que roda em outras máquinas sem exigir uma instalação do Python ou bibliotecas adicionais. Essa abordagem simplifica a distribuição de suas aplicações Python.

Congelar uma extensão Aspose.Slides for Python via .NET como dependência é ilustrado abaixo com um programa simples que usa Aspose.Slides.

## **PyInstaller**

De modo geral, nada especial é necessário ao empacotar um programa que depende de uma extensão Aspose.Slides for Python via .NET. Quando um programa importa a extensão de forma visível ao PyInstaller, a extensão será incluída no pacote. Como Aspose.Slides for Python via .NET inclui hooks do PyInstaller, suas dependências são detectadas automaticamente e copiadas para o bundle.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Entretanto, o PyInstaller pode ocasionalmente perder importações ocultas — módulos que são importados dinamicamente ou indiretamente pelo seu código. Para incluir uma importação oculta, use as opções do PyInstaller. As dependências da extensão são especificadas nos hooks do PyInstaller que acompanham Aspose.Slides for Python via .NET.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

Para congelar um programa com cx_Freeze, configure-o para incluir o pacote raiz da extensão Aspose.Slides for Python via .NET que você está usando. Isso garante que a extensão e todos os módulos dependentes sejam copiados para a build ao lado da sua aplicação.

### **Usando o script cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Usando o script Setup**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**Preciso do Microsoft PowerPoint ou .NET instalado na máquina do usuário?**

Não, o PowerPoint não é necessário. Aspose.Slides é um motor autônomo; o pacote Python envia tudo que é necessário como uma extensão para CPython. O usuário não precisa instalar .NET separadamente.

**Como devo anexar corretamente a licença a uma aplicação congelada?**

Você pode armazenar o XML da licença ao lado do executável ou incorporá‑lo como recurso e carregá‑lo a partir de um caminho acessível antes da primeira chamada de API. Importante: não modifique o conteúdo do XML (nem mesmo quebras de linha).

**O que fazer se as fontes forem renderizadas diferentemente após a build em comparação ao desenvolvimento?**

Certifique‑se de que as fontes que você usa estejam disponíveis no ambiente de destino (incluídas no bundle ou instaladas no sistema) e que seus caminhos sejam resolvidos corretamente em tempo de execução; o comportamento das fontes é especialmente sensível no Linux.