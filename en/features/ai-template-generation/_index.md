---
title: Generate presentations from a template
description: Use a template presentation when generating slides with AI.
type: docs
url: /features/ai-template-generation/
weight: 1550
feature_id: ai-template-generation
feature_group: ai
translationKey: slides-feature-ai-template-generation
feature_catalogue_version: 2
feature_guides:
- /slides/net/ai/generator/
---

## **Overview**

Pass a presentation template to the AI generator so the output can use its theme, fonts, masters and layouts. This gives generated slides a starting design drawn from your presentation file. It is a template-based library workflow, not a separately stored brand-kit service.

## **FAQ**

**Can I reuse one in-memory template for every request?**

Load a fresh copy for each generation when the template must stay unchanged. The generation workflow can modify the presentation instance passed to it.

## **Guides**

- [AI-Powered Multilingual Slide Generator (.NET)](/slides/net/ai/generator/)

Related feature: [Generate slides using an existing deck's style](/slides/features/ai-match-style/).
