---
title: Configure font fallback
description: Choose fallback fonts for specific character ranges.
type: docs
url: /features/font-fallback/
weight: 1240
feature_id: font-fallback
feature_group: rendering
translationKey: slides-feature-font-fallback
feature_catalogue_version: 2
feature_guides:
- /slides/net/fallback-font/
---

## **Overview**

Define ordered font fallbacks for characters missing from the preferred font. Rules can target Unicode ranges and list several fonts in order, helping multilingual presentations render with a suitable glyph source. Make those fonts available to the library before rendering.

## **FAQ**

**Does fallback order matter?**

Yes. The library tries the configured font sequence for the character range. Put the preferred fallback first.

## **Guides**

- [Manage Fallback Fonts for Presentations in .NET](/slides/net/fallback-font/)

Related feature: [Load fonts from a folder](/slides/features/custom-fonts/).
